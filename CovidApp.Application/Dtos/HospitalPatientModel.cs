using Microsoft.AspNetCore.Http;

namespace CovidApp.Application.Dtos
{
    public class HospitalPatientModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string DocumentId { get; set; }
        public IFormFile Photo { get; set; }
    }
}