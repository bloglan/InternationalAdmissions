using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentDocuments;

namespace AdmissionsPortalWebApp.Areas.Manage.Pages.ResidencePermits;

public class IndexModel(ResidencePermitManager permitManager) : PageModel
{
    public IEnumerable<PersonResidencePermit> Data { get; set; } = default!;

    public void OnGet()
    {
        Data = permitManager.Permits.ManagedBy(User).OrderByDescending(p => p.WhenCreated);
    }
}
