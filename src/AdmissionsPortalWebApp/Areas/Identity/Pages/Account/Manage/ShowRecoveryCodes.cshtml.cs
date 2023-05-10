

#nullable disable

using AdmissionsPortalWebApp.Areas.Identity.Pages.Account.Manage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdmissionsPortalWebApp.Areas.Identity.Pages.Account.Manage;

public class ShowRecoveryCodesModel : PageModel
{
    [TempData]
    public string[] RecoveryCodes { get; set; }

    [TempData]
    public string StatusMessage { get; set; }

    public IActionResult OnGet()
    {
        if (this.RecoveryCodes == null || this.RecoveryCodes.Length == 0)
        {
            return this.RedirectToPage("./TwoFactorAuthentication");
        }

        return this.Page();
    }
}
