namespace DotnetRestApi.Entities
{
    #region using

    using System.Text.Json.Serialization;

    #endregion

    public class Patient : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateBorn { get; set; }
        public int Age { get; set; }
        //public ICollection<MedicalTreatment> MedicalTreatments { get; set; }

        public int DoctorId { get; set; }
        [JsonIgnore]
        public Doctor Doctor { get; set; }
    }
}
