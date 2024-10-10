using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonIdentity;

namespace AdmissionsPortalWebApp.Areas.Identity.Pages.Account.Manage;

public class PersonalDataModel(
    UserManager<ApplicationUser> userManager) : PageModel
{
    public async Task<IActionResult> OnGet()
    {
        var user = await userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
        }

        return Page();
    }
}
