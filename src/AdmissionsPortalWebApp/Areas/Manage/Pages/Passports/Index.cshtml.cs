using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentDocuments;

namespace AdmissionsPortalWebApp.Areas.Manage.Pages.Passports;

public class IndexModel : PageModel
{
    private readonly PassportManager passportManager;

    public IndexModel(PassportManager passportManager)
    {
        this.passportManager = passportManager;
    }

    public IEnumerable<PersonPassport> Passports { get; set; } = default!;

    public void OnGet(string? q)
    {
        var passports = this.passportManager.Passports.ManagedBy(this.User);
        if (!string.IsNullOrEmpty(q))
        {
            passports = passports.Where(p => p.Passport.PassportNumber == q
            || p.Passport.Surname.Contains(q)
            || p.Passport.GivenName.Contains(q));
        }

        this.Passports = passports.OrderByDescending(p => p.WhenCreated);
    }
}
