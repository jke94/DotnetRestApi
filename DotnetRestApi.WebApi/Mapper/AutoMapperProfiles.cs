namespace DotnetRestApi.WebApi.Mapper
{
    #region 

    using AutoMapper;
    using DotnetRestApi.Entities;
    using DotnetRestApi.WebApi.DTOs;

    #endregion

    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Doctor, DoctorDto>();
            CreateMap<MedicalTreatment, MedicalTreatmentDto>();
            CreateMap<Patient, PatientDto>();
        }
    }
}
