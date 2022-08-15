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
    public class MedicalTreatmentController : ControllerBase
    {
        private IApplication<MedicalTreatment> _medicalTreatment;
        private Mapper _mapper;

        public MedicalTreatmentController(
            IApplication<MedicalTreatment> medicalTreatment,
            Mapper mapper)
        { 
            _medicalTreatment = medicalTreatment;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_medicalTreatment.GetAll());
        }

        [HttpPost]
        public IActionResult AddMedicalTreatment(MedicalTreatmentDto medicalTreatmentDto)
        {
            var element = _mapper.Map<MedicalTreatment>(medicalTreatmentDto);

            return Ok(_medicalTreatment.Save(element));
        }
    }
}
