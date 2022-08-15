namespace DotnetRestApi.WebApi.DTOs
{
    public class PatientDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateBorn { get; set; }
        public int Age { get; set; }
        public ICollection<MedicalTreatmentDto> MedicalTreatments { get; set; }

        //public int DoctorId { get; set; }
        public DoctorDto Doctor { get; set; }
    }
}
