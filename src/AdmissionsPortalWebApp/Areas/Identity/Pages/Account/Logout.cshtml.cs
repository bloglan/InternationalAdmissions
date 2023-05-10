#nullable disable

using AdmissionsPortalWebApp.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonIdentity;

namespace AdmissionsPortalWebApp.Areas.Identity.Pages.Account;

public class LogoutModel : PageModel
{
    private readonly SignInManager<Person> _signInManager;
    private readonly ILogger<LogoutModel> _logger;

    public LogoutModel(SignInManager<Person> signInManager, ILogger<LogoutModel> logger)
    {
        this._signInManager = signInManager;
        this._logger = logger;
    }

    public async Task<IActionResult> OnPost(string returnUrl = null)
    {
        await this._signInManager.SignOutAsync();
        this._logger.LogInformation("User logged out.");
        if (returnUrl != null)
        {
            return this.LocalRedirect(returnUrl);
        }
        else
        {
            // This needs to be a redirect so that the browser performs a new
            // request and the identity for the user gets updated.
            return this.RedirectToPage();
        }
    }
}
