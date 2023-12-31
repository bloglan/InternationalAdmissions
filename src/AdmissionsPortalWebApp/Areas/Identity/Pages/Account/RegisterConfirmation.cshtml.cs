﻿#nullable disable

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using PersonIdentity;
using System.Text;

namespace AdmissionsPortalWebApp.Areas.Identity.Pages.Account;

[AllowAnonymous]
public class RegisterConfirmationModel : PageModel
{
    private readonly UserManager<Person> _userManager;
    private readonly IEmailSender _sender;

    public RegisterConfirmationModel(UserManager<Person> userManager, IEmailSender sender)
    {
        this._userManager = userManager;
        this._sender = sender;
    }

    public string Email { get; set; }

    public bool DisplayConfirmAccountLink { get; set; }

    public string EmailConfirmationUrl { get; set; }

    public async Task<IActionResult> OnGetAsync(string email, string returnUrl = null)
    {
        if (email == null)
        {
            return this.RedirectToPage("/Index");
        }
        returnUrl ??= this.Url.Content("~/");

        var user = await this._userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return this.NotFound($"Unable to load user with email '{email}'.");
        }

        this.Email = email;
        // Once you add a real email sender, you should remove this code that lets you confirm the account
        this.DisplayConfirmAccountLink = true;
        if (this.DisplayConfirmAccountLink)
        {
            var userId = await this._userManager.GetUserIdAsync(user);
            var code = await this._userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            this.EmailConfirmationUrl = this.Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId, code, returnUrl },
                protocol: this.Request.Scheme);
        }

        return this.Page();
    }
}
