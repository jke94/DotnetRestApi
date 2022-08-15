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

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IApplication<Doctor> _doctor;
        private IMapper _mapper;
        private ILogger<DoctorController> _logger;

        public DoctorController(
            IApplication<Doctor> doctor,
            IMapper mapper,
            ILogger<DoctorController> logger)
        {
            _doctor = doctor;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_doctor.GetAll());
        }

        [HttpPost]
        public IActionResult AddMedicalTreatment(DoctorDto doctorDto)
        {
            if(doctorDto == null)
            {
                string message = "Object can not be null.";

                _logger.LogWarning(message);

                return BadRequest(message);
            }

            var element = _mapper.Map<Doctor>(doctorDto);

            if(element == null)
            {
                string message = "The structure of the object is not correct.";

                _logger.LogError(message);

                return BadRequest(message);
            }

            return Ok(_doctor.Save(element));
        }
    }
}
