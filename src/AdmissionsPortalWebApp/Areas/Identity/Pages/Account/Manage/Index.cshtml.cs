﻿

#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonIdentity;
using System.ComponentModel.DataAnnotations;

namespace AdmissionsPortalWebApp.Areas.Identity.Pages.Account.Manage;

public class IndexModel : PageModel
{
    private readonly UserManager<Person> _userManager;
    private readonly SignInManager<Person> _signInManager;

    public IndexModel(
        UserManager<Person> userManager,
        SignInManager<Person> signInManager)
    {
        this._userManager = userManager;
        this._signInManager = signInManager;
    }

    public string Username { get; set; }

    [TempData]
    public string StatusMessage { get; set; }

    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
    {
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }

    private async Task LoadAsync(Person user)
    {
        var userName = await this._userManager.GetUserNameAsync(user);
        var phoneNumber = await this._userManager.GetPhoneNumberAsync(user);

        this.Username = userName;

        this.Input = new InputModel
        {
            PhoneNumber = phoneNumber
        };
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

    public async Task<IActionResult> OnPostAsync()
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

        var phoneNumber = await this._userManager.GetPhoneNumberAsync(user);
        if (this.Input.PhoneNumber != phoneNumber)
        {
            var setPhoneResult = await this._userManager.SetPhoneNumberAsync(user, this.Input.PhoneNumber);
            if (!setPhoneResult.Succeeded)
            {
                this.StatusMessage = "Unexpected error when trying to set phone number.";
                return this.RedirectToPage();
            }
        }

        await this._signInManager.RefreshSignInAsync(user);
        this.StatusMessage = "Your profile has been updated";
        return this.RedirectToPage();
    }
}
