namespace DotnetRestApi.WebApi.DTOs
{
    public class DoctorDto 
    {
        public string Name { get; set; }
        public string Surname { get; set; } = string.Empty;
        public DateTime DateBorn { get; set; }
        public int Age { get; set; }

        //public ICollection<PatientDto> Patients { get; set; }
    }
}
