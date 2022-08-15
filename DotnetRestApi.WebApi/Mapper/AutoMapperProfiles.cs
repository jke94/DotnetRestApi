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
            CreateMap<DoctorDto, Doctor>();
            CreateMap<MedicalTreatmentDto, MedicalTreatment>();
            CreateMap<PatientDto, Patient>();
        }
    }
}
