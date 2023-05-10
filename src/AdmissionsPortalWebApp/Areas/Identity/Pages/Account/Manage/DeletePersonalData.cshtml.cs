

#nullable disable

using AdmissionsPortalWebApp.Areas.Identity.Pages.Account.Manage;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonIdentity;
using System.ComponentModel.DataAnnotations;

namespace AdmissionsPortalWebApp.Areas.Identity.Pages.Account.Manage;

public class DeletePersonalDataModel : PageModel
{
    private readonly UserManager<Person> _userManager;
    private readonly SignInManager<Person> _signInManager;
    private readonly ILogger<DeletePersonalDataModel> _logger;

    public DeletePersonalDataModel(
        UserManager<Person> userManager,
        SignInManager<Person> signInManager,
        ILogger<DeletePersonalDataModel> logger)
    {
        this._userManager = userManager;
        this._signInManager = signInManager;
        this._logger = logger;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public bool RequirePassword { get; set; }

    public async Task<IActionResult> OnGet()
    {
        var user = await this._userManager.GetUserAsync(this.User);
        if (user == null)
        {
            return this.NotFound($"Unable to load user with ID '{this._userManager.GetUserId(this.User)}'.");
        }

        this.RequirePassword = await this._userManager.HasPasswordAsync(user);
        return this.Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var user = await this._userManager.GetUserAsync(this.User);
        if (user == null)
        {
            return this.NotFound($"Unable to load user with ID '{this._userManager.GetUserId(this.User)}'.");
        }

        this.RequirePassword = await this._userManager.HasPasswordAsync(user);
        if (this.RequirePassword)
        {
            if (!await this._userManager.CheckPasswordAsync(user, this.Input.Password))
            {
                this.ModelState.AddModelError(string.Empty, "Incorrect password.");
                return this.Page();
            }
        }

        var result = await this._userManager.DeleteAsync(user);
        var userId = await this._userManager.GetUserIdAsync(user);
        if (!result.Succeeded)
        {
            throw new InvalidOperationException($"Unexpected error occurred deleting user.");
        }

        await this._signInManager.SignOutAsync();

        this._logger.LogInformation("User with ID '{UserId}' deleted themselves.", userId);

        return this.Redirect("~/");
    }
}
