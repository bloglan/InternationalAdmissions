﻿#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonIdentity;

namespace AdmissionsPortalWebApp.Areas.Identity.Pages.Account.Manage;

public class TwoFactorAuthenticationModel(
    UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : PageModel
{
    public bool HasAuthenticator { get; set; }

    public int RecoveryCodesLeft { get; set; }

    [BindProperty]
    public bool Is2FaEnabled { get; set; }

    public bool IsMachineRemembered { get; set; }

    [TempData]
    public string StatusMessage { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var user = await userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
        }

        HasAuthenticator = await userManager.GetAuthenticatorKeyAsync(user) != null;
        Is2FaEnabled = await userManager.GetTwoFactorEnabledAsync(user);
        IsMachineRemembered = await signInManager.IsTwoFactorClientRememberedAsync(user);
        RecoveryCodesLeft = await userManager.CountRecoveryCodesAsync(user);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var user = await userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
        }

        await signInManager.ForgetTwoFactorClientAsync();
        StatusMessage = "The current browser has been forgotten. When you login again from this browser you will be prompted for your 2fa code.";
        return RedirectToPage();
    }
}
