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
        private Mapper _mapper;

        public DoctorController(
            IApplication<Doctor> doctor,
            Mapper mapper)
        {
            _doctor = doctor;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_doctor.GetAll());
        }

        [HttpPost]
        public IActionResult AddMedicalTreatment(DoctorDto doctorDto)
        {
            var element = _mapper.Map<Doctor>(doctorDto);

            return Ok(_doctor.Save(element));
        }
    }
}
