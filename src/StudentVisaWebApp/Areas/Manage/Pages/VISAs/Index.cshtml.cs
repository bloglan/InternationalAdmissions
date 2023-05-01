using Microsoft.AspNetCore.Mvc.RazorPages;
using VisaManagement;

namespace StudentVisaWebApp.Areas.Manage.Pages.VISAs;

public class IndexModel : PageModel
{
    private readonly VisaManager visaManager;

    public IndexModel(VisaManager visaManager)
    {
        this.visaManager = visaManager;
    }

    public IEnumerable<PersonVisa> Visas { get; set; } = default!;

    public void OnGet(string? q)
    {
        var visas = this.visaManager.Visas.ManagedBy(this.User);
        if (!string.IsNullOrEmpty(q))
        {
            visas = visas.Where(p => p.Visa.VisaNumber == q
            || p.Visa.FullName.Contains(q)
            || p.Visa.PassportNumber == q);
        }

        this.Visas = visas.OrderByDescending(p => p.WhenCreated);
    }
}
