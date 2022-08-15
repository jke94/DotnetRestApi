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
    public class PatientController : ControllerBase
    {
        private IApplication<Patient> _patient;
        private Mapper _mapper;

        public PatientController(
            IApplication<Patient> patient,
            Mapper mapper)
        {
            _patient = patient;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_patient.GetAll());
        }

        [HttpPost]
        public IActionResult AddPatient(PatientDto patientDto)
        {
            var element = _mapper.Map<Patient>(patientDto);

            return Ok(_patient.Save(element));
        }
    }
}
