

#nullable disable

using AdmissionsPortalWebApp.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using PersonIdentity;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace AdmissionsPortalWebApp.Areas.Identity.Pages.Account;

[AllowAnonymous]
public class ExternalLoginModel : PageModel
{
    private readonly SignInManager<Person> _signInManager;
    private readonly UserManager<Person> _userManager;
    private readonly IUserStore<Person> _userStore;
    private readonly IUserEmailStore<Person> _emailStore;
    private readonly IEmailSender _emailSender;
    private readonly ILogger<ExternalLoginModel> _logger;

    public ExternalLoginModel(
        SignInManager<Person> signInManager,
        UserManager<Person> userManager,
        IUserStore<Person> userStore,
        ILogger<ExternalLoginModel> logger,
        IEmailSender emailSender)
    {
        this._signInManager = signInManager;
        this._userManager = userManager;
        this._userStore = userStore;
        this._emailStore = this.GetEmailStore();
        this._logger = logger;
        this._emailSender = emailSender;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public string ProviderDisplayName { get; set; }

    public string ReturnUrl { get; set; }

    [TempData]
    public string ErrorMessage { get; set; }

    public class InputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

    public IActionResult OnGet() => this.RedirectToPage("./Login");

    public IActionResult OnPost(string provider, string returnUrl = null)
    {
        // Request a redirect to the external login provider.
        var redirectUrl = this.Url.Page("./ExternalLogin", pageHandler: "Callback", values: new { returnUrl });
        var properties = this._signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        return new ChallengeResult(provider, properties);
    }

    public async Task<IActionResult> OnGetCallbackAsync(string returnUrl = null, string remoteError = null)
    {
        returnUrl ??= this.Url.Content("~/");
        if (remoteError != null)
        {
            this.ErrorMessage = $"Error from external provider: {remoteError}";
            return this.RedirectToPage("./Login", new { ReturnUrl = returnUrl });
        }
        var info = await this._signInManager.GetExternalLoginInfoAsync();
        if (info == null)
        {
            this.ErrorMessage = "Error loading external login information.";
            return this.RedirectToPage("./Login", new { ReturnUrl = returnUrl });
        }

        // Sign in the user with this external login provider if the user already has a login.
        var result = await this._signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
        if (result.Succeeded)
        {
            this._logger.LogInformation("{Name} logged in with {LoginProvider} provider.", info.Principal.Identity.Name, info.LoginProvider);
            return this.LocalRedirect(returnUrl);
        }
        if (result.IsLockedOut)
        {
            return this.RedirectToPage("./Lockout");
        }
        else
        {
            // If the user does not have an account, then ask the user to create an account.
            this.ReturnUrl = returnUrl;
            this.ProviderDisplayName = info.ProviderDisplayName;
            if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Email))
            {
                this.Input = new InputModel
                {
                    Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                };
            }
            return this.Page();
        }
    }

    public async Task<IActionResult> OnPostConfirmationAsync(string returnUrl = null)
    {
        returnUrl ??= this.Url.Content("~/");
        // Get the information about the user from the external login provider
        var info = await this._signInManager.GetExternalLoginInfoAsync();
        if (info == null)
        {
            this.ErrorMessage = "Error loading external login information during confirmation.";
            return this.RedirectToPage("./Login", new { ReturnUrl = returnUrl });
        }

        if (this.ModelState.IsValid)
        {
            var user = this.CreateUser();

            await this._userStore.SetUserNameAsync(user, this.Input.Email, CancellationToken.None);
            await this._emailStore.SetEmailAsync(user, this.Input.Email, CancellationToken.None);

            var result = await this._userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                result = await this._userManager.AddLoginAsync(user, info);
                if (result.Succeeded)
                {
                    this._logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);

                    var userId = await this._userManager.GetUserIdAsync(user);
                    var code = await this._userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = this.Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId, code },
                        protocol: this.Request.Scheme);

                    await this._emailSender.SendEmailAsync(this.Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    // If account confirmation is required, we need to show the link if we don't have a real email sender
                    if (this._userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return this.RedirectToPage("./RegisterConfirmation", new { this.Input.Email });
                    }

                    await this._signInManager.SignInAsync(user, isPersistent: false, info.LoginProvider);
                    return this.LocalRedirect(returnUrl);
                }
            }
            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        this.ProviderDisplayName = info.ProviderDisplayName;
        this.ReturnUrl = returnUrl;
        return this.Page();
    }

    private Person CreateUser()
    {
        try
        {
            return Activator.CreateInstance<Person>();
        }
        catch
        {
            throw new InvalidOperationException($"Can't create an instance of '{nameof(Person)}'. " +
                $"Ensure that '{nameof(Person)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                $"override the external login page in /Areas/Identity/Pages/Account/ExternalLogin.cshtml");
        }
    }

    private IUserEmailStore<Person> GetEmailStore()
    {
        if (!this._userManager.SupportsUserEmail)
        {
            throw new NotSupportedException("The default UI requires a user store with email support.");
        }
        return (IUserEmailStore<Person>)this._userStore;
    }
}
