﻿

#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using PersonIdentity;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;

namespace AdmissionsPortalWebApp.Areas.Identity.Pages.Account.Manage;

public class EmailModel : PageModel
{
    private readonly UserManager<Person> _userManager;
    private readonly SignInManager<Person> _signInManager;
    private readonly IEmailSender _emailSender;

    public EmailModel(
        UserManager<Person> userManager,
        SignInManager<Person> signInManager,
        IEmailSender emailSender)
    {
        this._userManager = userManager;
        this._signInManager = signInManager;
        this._emailSender = emailSender;
    }

    public string Email { get; set; }

    public bool IsEmailConfirmed { get; set; }

    [TempData]
    public string StatusMessage { get; set; }

    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "New email")]
        public string NewEmail { get; set; }
    }

    private async Task LoadAsync(Person user)
    {
        var email = await this._userManager.GetEmailAsync(user);
        this.Email = email;

        this.Input = new InputModel
        {
            NewEmail = email,
        };

        this.IsEmailConfirmed = await this._userManager.IsEmailConfirmedAsync(user);
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var user = await this._userManager.GetUserAsync(this.User);
        if (user == null)
        {
            return this.NotFound($"Unable to load user with ID '{this._userManager.GetUserId(this.User)}'.");
        }

        await this.LoadAsync(user);
        return this.Page();
    }

    public async Task<IActionResult> OnPostChangeEmailAsync()
    {
        var user = await this._userManager.GetUserAsync(this.User);
        if (user == null)
        {
            return this.NotFound($"Unable to load user with ID '{this._userManager.GetUserId(this.User)}'.");
        }

        if (!this.ModelState.IsValid)
        {
            await this.LoadAsync(user);
            return this.Page();
        }

        var email = await this._userManager.GetEmailAsync(user);
        if (this.Input.NewEmail != email)
        {
            var userId = await this._userManager.GetUserIdAsync(user);
            var code = await this._userManager.GenerateChangeEmailTokenAsync(user, this.Input.NewEmail);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = this.Url.Page(
                "/Account/ConfirmEmailChange",
                pageHandler: null,
                values: new { area = "Identity", userId, email = this.Input.NewEmail, code },
                protocol: this.Request.Scheme);
            await this._emailSender.SendEmailAsync(
                this.Input.NewEmail,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            this.StatusMessage = "Confirmation link to change email sent. Please check your email.";
            return this.RedirectToPage();
        }

        this.StatusMessage = "Your email is unchanged.";
        return this.RedirectToPage();
    }

    public async Task<IActionResult> OnPostSendVerificationEmailAsync()
    {
        var user = await this._userManager.GetUserAsync(this.User);
        if (user == null)
        {
            return this.NotFound($"Unable to load user with ID '{this._userManager.GetUserId(this.User)}'.");
        }

        if (!this.ModelState.IsValid)
        {
            await this.LoadAsync(user);
            return this.Page();
        }

        var userId = await this._userManager.GetUserIdAsync(user);
        var email = await this._userManager.GetEmailAsync(user);
        var code = await this._userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        var callbackUrl = this.Url.Page(
            "/Account/ConfirmEmail",
            pageHandler: null,
            values: new { area = "Identity", userId, code },
            protocol: this.Request.Scheme);
        await this._emailSender.SendEmailAsync(
            email,
            "Confirm your email",
            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        this.StatusMessage = "Verification email sent. Please check your email.";
        return this.RedirectToPage();
    }
}
