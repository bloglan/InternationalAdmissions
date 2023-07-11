

#nullable disable

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using PersonIdentity;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;

namespace AdmissionsPortalWebApp.Areas.Identity.Pages.Account;

public class RegisterModel : PageModel
{
    private readonly SignInManager<Person> _signInManager;
    private readonly UserManager<Person> _userManager;
    private readonly IUserStore<Person> _userStore;
    private readonly IUserEmailStore<Person> _emailStore;
    private readonly ILogger<RegisterModel> _logger;
    private readonly IEmailSender _emailSender;

    public RegisterModel(
        UserManager<Person> userManager,
        IUserStore<Person> userStore,
        SignInManager<Person> signInManager,
        ILogger<RegisterModel> logger,
        IEmailSender emailSender)
    {
        this._userManager = userManager;
        this._userStore = userStore;
        this._emailStore = this.GetEmailStore();
        this._signInManager = signInManager;
        this._logger = logger;
        this._emailSender = emailSender;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public string ReturnUrl { get; set; }

    public IList<AuthenticationScheme> ExternalLogins { get; set; }

    public class InputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Sex")]
        public Sex? Sex { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
    }


    public async Task OnGetAsync(string returnUrl = null)
    {
        this.ReturnUrl = returnUrl;
        this.ExternalLogins = (await this._signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
    }

    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    {
        returnUrl ??= this.Url.Content("~/");
        this.ExternalLogins = (await this._signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        if (this.ModelState.IsValid)
        {
            var user = this.CreateUser();

            await this._userStore.SetUserNameAsync(user, this.Input.Email, CancellationToken.None);
            await this._emailStore.SetEmailAsync(user, this.Input.Email, CancellationToken.None);
            user.Name = this.Input.Name;
            user.Sex = this.Input.Sex;
            user.BirthDate = this.Input.BirthDate;
            var result = await this._userManager.CreateAsync(user, this.Input.Password);

            if (result.Succeeded)
            {
                this._logger.LogInformation("User created a new account with password.");

                var userId = await this._userManager.GetUserIdAsync(user);
                var code = await this._userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = this.Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { area = "Identity", userId, code, returnUrl },
                    protocol: this.Request.Scheme);

                await this._emailSender.SendEmailAsync(this.Input.Email, "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                if (this._userManager.Options.SignIn.RequireConfirmedAccount)
                {
                    return this.RedirectToPage("RegisterConfirmation", new { email = this.Input.Email, returnUrl });
                }
                else
                {
                    await this._signInManager.SignInAsync(user, isPersistent: false);
                    return this.LocalRedirect(returnUrl);
                }
            }
            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        // If we got this far, something failed, redisplay form
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
                $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
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
