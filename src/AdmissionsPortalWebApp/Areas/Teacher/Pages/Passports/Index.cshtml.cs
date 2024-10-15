using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentDocuments;

namespace AdmissionsPortalWebApp.Areas.Teacher.Pages.Passports;

public class IndexModel(PassportManager passportManager) : PageModel
{
    public IEnumerable<PersonPassport> Passports { get; set; } = default!;

    public void OnGet(string? q)
    {
        var passports = passportManager.Passports.ManagedBy(User);
        if (!string.IsNullOrEmpty(q))
        {
            passports = passports.Where(p => p.Passport.PassportNumber == q
            || p.Passport.Surname.Contains(q)
            || p.Passport.GivenName.Contains(q));
        }

        Passports = passports.OrderByDescending(p => p.WhenCreated);
    }
}
