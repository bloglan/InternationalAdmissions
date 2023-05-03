using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VisaManagement;

namespace StudentVisaWebApp.Areas.Manage.Pages.Passports;

public class DetailModel : PageModel
{
    private readonly PassportManager passportManager;
    private readonly VisaManager visaManager;

    public DetailModel(PassportManager passportManager, VisaManager visaManager)
    {
        this.passportManager = passportManager;
        this.visaManager = visaManager;
    }

    public PersonPassport Data { get; set; } = default!;

    public IEnumerable<PersonVisa> Visas { get; set; } = default!;

    public async Task<IActionResult> OnGet(int id)
    {
        var passport = await this.passportManager.FindByIdAsync(id);
        if (passport == null)
        {
            return this.NotFound();
        }
        this.Data = passport;
        this.Visas = this.visaManager.FindByPassportNumber(passport.Passport.PassportNumber);
        return this.Page();
    }
}
