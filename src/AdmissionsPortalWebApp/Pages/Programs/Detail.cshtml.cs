using Admissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdmissionsPortalWebApp.Pages.Programs
{
    public class DetailModel(AdmissionPlanManager manager) : PageModel
    {
        public AdmissionPlan Plan { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            AdmissionPlan? plan = manager.VisiblePlans.FirstOrDefault(p => p.Id == id);
            if (plan == null)
            {
                return NotFound();
            }

            Plan = plan;
            return Page();
        }
    }
}
