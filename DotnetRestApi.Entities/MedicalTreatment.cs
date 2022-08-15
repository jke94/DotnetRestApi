namespace DotnetRestApi.Entities
{
    public class MedicalTreatment : Entity
    {
        public string Medicine { get; set; }
        public int Days { get; set; }

        //public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
