namespace DotnetRestApi.Entities
{
    #region using

    using System.Collections.Generic;

    #endregion

    public class Doctor : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateBorn { get; set; }
        public int Age { get; set; }

        public ICollection<Patient> Patients { get; set; }
    }
}
