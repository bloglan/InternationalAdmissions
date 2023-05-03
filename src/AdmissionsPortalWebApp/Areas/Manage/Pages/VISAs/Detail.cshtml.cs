using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VisaManagement;

namespace StudentVisaWebApp.Areas.Manage.Pages.VISAs;

public class DetailModel : PageModel
{
    private readonly VisaManager visaManager;
    private readonly PassportManager passportManager;

    public DetailModel(VisaManager visaManager, PassportManager passportManager)
    {
        this.visaManager = visaManager;
        this.passportManager = passportManager;
    }

    public PersonVisa Data { get; set; } = default!;
    public PersonPassport? Passport { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var data = await this.visaManager.FindByIdAsync(id);
        if (data == null)
            return this.NotFound();

        this.Data = data;
        this.Passport = this.passportManager.FindByPassportNumber(this.Data.Visa.PassportNumber);
        return this.Page();
    }
}
