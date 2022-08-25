namespace DotnetRestApi.WebApi.DTOs
{
    public class PatientDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateBorn { get; set; }
        public int Age { get; set; }
        //public ICollection<MedicalTreatment> MedicalTreatments { get; set; }

        public int DoctorDtoId { get; set; }
        //public DoctorDto DoctorDto { get; set; }
    }
}
