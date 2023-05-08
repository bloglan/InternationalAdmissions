using Microsoft.AspNetCore.Mvc.RazorPages;
using VisaManagement;

namespace StudentVisaWebApp.Areas.Manage.Pages.ResidencePermits;

public class IndexModel : PageModel
{
    private readonly ResidencePermitManager permitManager;

    public IndexModel(ResidencePermitManager permitManager)
    {
        this.permitManager = permitManager;
    }

    public IEnumerable<PersonResidencePermit> Data { get; set; } = default!;

    public void OnGet()
    {
        this.Data = this.permitManager.Permits.ManagedBy(this.User).OrderByDescending(p => p.WhenCreated);
    }
}
