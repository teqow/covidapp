using System;

namespace CovidApp.Domain.HospitalPatient
{
    public class HospitalPatient
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public string DocumentId { get; private set; }
        public string Photo { get; private set; }
        public DateTime CreatedOn { get; private set; }

        private HospitalPatient(Guid id, string firstName, string lastName, int age, string documentId, string photo, DateTime createdOn)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            DocumentId = documentId;
            Photo = photo;
            CreatedOn = createdOn;
        }

        public static HospitalPatient Create(Guid id, string firstName, string lastName, int age, string documentId, string photo)
        {
            return new HospitalPatient(id, firstName, lastName, age, documentId, photo, DateTime.UtcNow);
        }
    }
}