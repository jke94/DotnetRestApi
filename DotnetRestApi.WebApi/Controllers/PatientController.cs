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
    using Microsoft.Extensions.Logging;

    #endregion

    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IApplication<Patient> _patient;
        private IApplication<Doctor> _doctor;
        private IMapper _mapper;
        private ILogger<PatientController> _logger;

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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_patient.GetAll());
        }

        [HttpPost]
        public IActionResult AddPatient(PatientDto patientDto)
        {
            if (patientDto == null)
            {
                string message = "Object can not be null.";

                _logger.LogWarning(message);

                return BadRequest(message);
            }

            var doctor = _doctor.GetById(patientDto.DoctorDtoId);

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
    }
}
