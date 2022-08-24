namespace DotnetRestApi.WebApi.Controllers
{
    #region

    using DotnetRestApi.Abstractions.Application;
    using DotnetRestApi.Entities;
    using DotnetRestApi.WebApi.DTOs;
    using Microsoft.AspNetCore.Mvc;
    using AutoMapper;
    using Microsoft.Extensions.Logging;

    #endregion

    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        #region Fields

        private IApplication<Patient> _patient;
        private IApplication<Doctor> _doctor;
        private IMapper _mapper;
        private ILogger<PatientController> _logger;

        #endregion

        #region Constructor

        public PatientController(
            IApplication<Patient> patient,
            IApplication<Doctor> doctor,
            IMapper mapper,
            ILogger<PatientController> logger)
        {
            _patient = patient;
            _doctor = doctor;
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Methods: HTTP GET

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_patient.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPatientId(int id)
        {
            try
            {
                var result = await Task.Run(() => _patient.GetById(id));

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        #endregion

        #region Methods: HTTP POST

        [HttpPost]
        public IActionResult AddPatient(PatientDto patientDto)
        {
            try
            {
                if (patientDto == null)
                {
                    string message = "Object can not be null.";

                    _logger.LogWarning(message);

                    return BadRequest(message);
                }

                var doctor = _doctor.GetById(patientDto.DoctorDtoId);

                if (doctor == null)
                {
                    string message = $"The doctor with the id: {patientDto.DoctorDtoId}, doesn´t exists.";

                    _logger.LogWarning(message);

                    return BadRequest(message);
                }

                var element = _mapper.Map<Patient>(patientDto);
                element.Doctor = doctor;

                if (element == null)
                {
                    string message = "The structure of the object is not correct.";

                    _logger.LogError(message);

                    return BadRequest(message);
                }

                return Ok(_patient.Save(element));
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        #endregion

        #region Methods: HTTP PUT

        [HttpPut]
        public async Task<IActionResult> Put(int id, PatientDto patientDto)
        {
            try
            {
                if (patientDto == null)
                {
                    string message = "Object can not be null.";

                    _logger.LogWarning(message);

                    return BadRequest(message);
                }

                var result = await Task.Run(() => _patient.GetById(id));

                if (result == null)
                {
                    string message = $"The patient with the id: {id}, doesn´t exists.";

                    _logger.LogWarning(message);

                    return BadRequest(message);
                }

                // Update fields
                result.Name = patientDto.Name;
                result.Surname = patientDto.Surname;
                result.DateBorn = patientDto.DateBorn;
                result.Age = patientDto.Age;
                result.DoctorId = patientDto.DoctorDtoId;
              
                return Ok(_patient.Update(result));
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
