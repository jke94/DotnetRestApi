namespace DotnetRestApi.Entities
{
    public class MedicalTreatment : Entity
    {
        public string Medicine { get; set; }
        public int Days { get; set; }

        public ICollection<Patient> Patients { get; set; }
    }
}
