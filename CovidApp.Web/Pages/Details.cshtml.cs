using System;
using System.Threading.Tasks;
using CovidApp.Application;
using CovidApp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CovidApp.Web.Pages
{
    public class Details : PageModel
    {
        private readonly IHospitalPatientService _service;

        public Details(IHospitalPatientService service)
        {
            _service = service;
        }
                    
        [BindProperty(SupportsGet = true)]
        public HospitalPatientDetailsDto HospitalPatient { get; set; } = new HospitalPatientDetailsDto();
        public async Task OnGetAsync(Guid id)
        {
            HospitalPatient = await _service.GetHospitalPatientDetailsAsync(id);
        }
    }
}