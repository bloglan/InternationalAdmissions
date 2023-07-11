

#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using PersonIdentity;
using System.Text;

namespace AdmissionsPortalWebApp.Areas.Identity.Pages.Account;

public class ConfirmEmailModel : PageModel
{
    private readonly UserManager<Person> _userManager;

    public ConfirmEmailModel(UserManager<Person> userManager)
    {
        this._userManager = userManager;
    }

    [TempData]
    public string StatusMessage { get; set; }
    public async Task<IActionResult> OnGetAsync(string userId, string code)
    {
        if (userId == null || code == null)
        {
            return this.RedirectToPage("/Index");
        }

        var user = await this._userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return this.NotFound($"Unable to load user with ID '{userId}'.");
        }

        code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        var result = await this._userManager.ConfirmEmailAsync(user, code);
        this.StatusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";
        return this.Page();
    }
}
