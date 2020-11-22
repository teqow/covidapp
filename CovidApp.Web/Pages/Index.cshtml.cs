using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CovidApp.Application;
using CovidApp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CovidApp.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHospitalPatientService _service;

        public IndexModel(IHospitalPatientService service)
        {
            _service = service;
        }

        [BindProperty(SupportsGet = true)]
        public List<HospitalPatientsDto> HospitalPatients { get; set; } = new List<HospitalPatientsDto>();
        public async Task OnGetAsync()
        {
             HospitalPatients = await _service.GetHostpialPatientsAsync();
        }
    }
}