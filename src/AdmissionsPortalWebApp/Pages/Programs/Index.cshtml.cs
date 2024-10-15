using Admissions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdmissionsPortalWebApp.Pages.Programs
{
    public class IndexModel(AdmissionPlanManager manager) : PageModel
    {
        public IEnumerable<AdmissionPlan> Plans { get; set; } = [];

        public void OnGet()
        {
            Plans = manager.VisiblePlans;
        }
    }
}
