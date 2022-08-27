namespace DotnetRestApi.WebApi.Controllers
{
    #region

    using DotnetRestApi.Abstractions.Application;
    using DotnetRestApi.Entities;
    using DotnetRestApi.WebApi.DTOs;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using AutoMapper;

    #endregion

    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        #region Fields

        private IApplication<Doctor> _doctor;
        private IMapper _mapper;
        private ILogger<DoctorController> _logger;

        #endregion

        #region Constructor

        public DoctorController(
            IApplication<Doctor> doctor,
            IMapper mapper,
            ILogger<DoctorController> logger)
        {
            _doctor = doctor;
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region HTTP GET

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var taskResult = await Task.Run(() => _doctor.GetAll());

            return Ok(taskResult);
        }

        #endregion

        #region HTTP POST

        [HttpPost]
        public async Task<IActionResult> AddMedicalTreatment(DoctorDto doctorDto)
        {
            if(doctorDto == null)
            {
                string message = "Object can not be null.";

                _logger.LogWarning(message);

                return BadRequest(message);
            }

            var element = await Task.Run(() => _mapper.Map<Doctor>(doctorDto));

            if (element == null)
            {
                string message = "The structure of the object is not correct.";

                _logger.LogError(message);

                return BadRequest(message);
            }

            return Ok(_doctor.Save(element));
        }

        #endregion

        #region HTTP PUT

        [HttpPut]
        public async Task<IActionResult> Put(int id, DoctorDto doctorDto)
        {
            try
            {
                if (doctorDto == null)
                {
                    string message = "Object can not be null.";

                    _logger.LogWarning(message);

                    return BadRequest(message);
                }

                var result = await Task.Run(() => _doctor.GetById(id));

                if (result == null)
                {
                    string message = $"The doctor with the id: {id}, doesn´t exists.";

                    _logger.LogWarning(message);

                    return BadRequest(message);
                }

                // Update fields
                result.Name = doctorDto.Name;
                result.Surname = doctorDto.Surname;
                result.DateBorn = doctorDto.DateBorn;
                result.Age = doctorDto.Age;

                return Ok(_doctor.Update(result));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        #endregion
    }
}
