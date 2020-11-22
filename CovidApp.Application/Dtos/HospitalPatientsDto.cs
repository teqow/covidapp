using System;

namespace CovidApp.Application.Dtos
{
    public class HospitalPatientsDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentId { get; set; }
    }
}