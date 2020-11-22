using System.Threading.Tasks;
using CovidApp.Application;
using CovidApp.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CovidApp.Web.Pages
{
    public class PatientModel : PageModel
    {
        private readonly IHospitalPatientService _service;
        public PatientModel(IHospitalPatientService service)
        {
            _service = service;
        }

        [BindProperty]
        public HospitalPatientModel HospitalPatient { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _service.AddAsync(HospitalPatient);

            return RedirectToPage("./Index");
        }
    }
}