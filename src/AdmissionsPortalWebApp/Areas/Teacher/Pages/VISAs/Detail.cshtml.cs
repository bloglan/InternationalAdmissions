using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentDocuments;

namespace AdmissionsPortalWebApp.Areas.Teacher.Pages.VISAs;

public class DetailModel(VisaManager visaManager, PassportManager passportManager) : PageModel
{
    public PersonVisa Data { get; set; } = default!;
    public PersonPassport? Passport { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var data = await visaManager.FindByIdAsync(id);
        if (data == null)
            return NotFound();

        Data = data;
        Passport = passportManager.FindByPassportNumber(Data.Visa.PassportNumber);
        return Page();
    }
}
