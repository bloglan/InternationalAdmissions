using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentDocuments;

namespace AdmissionsPortalWebApp.Areas.Manage.Pages.VISAs;

public class IndexModel(VisaManager visaManager) : PageModel
{
    public IEnumerable<PersonVisa> Visas { get; set; } = default!;

    public void OnGet(string? q)
    {
        var visas = visaManager.Visas.ManagedBy(User);
        if (!string.IsNullOrEmpty(q))
        {
            visas = visas.Where(p => p.Visa.VisaNumber == q
            || p.Visa.FullName.Contains(q)
            || p.Visa.PassportNumber == q);
        }

        Visas = visas.OrderByDescending(p => p.WhenCreated);
    }
}
