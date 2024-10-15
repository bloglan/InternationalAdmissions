using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentDocuments;

namespace AdmissionsPortalWebApp.Areas.Teacher.Pages.Passports;

public class DetailModel(PassportManager passportManager, VisaManager visaManager) : PageModel
{
    public PersonPassport Data { get; set; } = default!;

    public IEnumerable<PersonVisa> Visas { get; set; } = default!;

    public async Task<IActionResult> OnGet(int id)
    {
        var passport = await passportManager.FindByIdAsync(id);
        if (passport == null)
        {
            return NotFound();
        }
        Data = passport;
        Visas = visaManager.FindByPassportNumber(passport.Passport.PassportNumber);
        return Page();
    }
}
