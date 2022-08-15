namespace DotnetRestApi.WebApi.DTOs
{
    public class MedicalTreatmentDto
    {
        public string Medicine { get; set; }
        public int Days { get; set; }

        //public int PatientId { get; set; }
        public PatientDto Patient { get; set; }
    }
}
