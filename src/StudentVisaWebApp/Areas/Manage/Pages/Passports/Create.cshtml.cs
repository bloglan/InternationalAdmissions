using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using VisaManagement;

namespace StudentVisaWebApp.Areas.Manage.Pages.Passports
{
    public class CreateModel : PageModel
    {
        readonly PassportManager passportManager;

        public CreateModel(PassportManager passportManager)
        {
            this.passportManager = passportManager;
        }

        [BindProperty]
        public InputModel Input { get; set; } = default!;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!this.ModelState.IsValid)
            {
                return this.Page();
            }

            PersonPassport passport = new()
            {
                Passport = new()
                {
                    Type = this.Input.Type,
                    CountryCode = this.Input.CountryCode,
                    PassportNumber = this.Input.PassportNumber,
                    Surname = this.Input.Surname,
                    GivenName = this.Input.GivenName,
                    Sex = this.Input.Sex,
                    Nationality = this.Input.Nationality,
                    DateOfBirth = this.Input.DateOfBirth,
                    PlaceOfBirth = this.Input.PlaceOfBirth,
                    DateOfIssue = this.Input.DateOfIssue,
                    DateOfExpiration = this.Input.DateOfExpiration,
                    Authority = this.Input.Authority,
                },
                Manager = new()
                {
                    Id = this.User.UserId()!,
                    Name = this.User.Identity!.Name!,
                },
            };
            var result = await this.passportManager.CreateAsync(passport);
            if(result.IsSuccess)
            {
                return this.RedirectToPage("Index");
            }

            foreach(var error in result.Errors)
            {
                this.ModelState.AddModelError("", error);
            }
            return this.Page();
        }

        public class InputModel
        {
            [Display(Name = "Type")]
            [StringLength(5)]
            public string Type { get; set; } = default!;

            [Display(Name = "Country Code")]
            [StringLength(5)]
            public string CountryCode { get; set; } = default!;

            [Display(Name = "Passport Number")]
            [StringLength(9,MinimumLength =9)]
            public string PassportNumber { get; set; } = default!;

            [Display(Name = "Surname")]
            [StringLength(20)]
            public string Surname { get; set; } = default!;

            [Display(Name = "Given Name")]
            [StringLength(20)]
            public string GivenName { get; set; } = default!;

            [Display(Name = "Sex")]
            [StringLength(5)]
            public string Sex { get; set; } = default!;

            [Display(Name = "Nationality")]
            [StringLength(50)]
            public string Nationality { get; set; } = default!;

            [Display(Name = "Date Of Birth")]
            [DataType(DataType.Date)]
            public DateTime DateOfBirth { get; set; }

            [Display(Name = "Place Of Birth")]
            [StringLength(50)]
            public string PlaceOfBirth { get; set; } = default!;

            [Display(Name = "Date Of Issue")]
            [DataType(DataType.Date)]
            public DateTime DateOfIssue { get; set; }

            [Display(Name = "Date Of Expiration")]
            [DataType(DataType.Date)]
            public DateTime DateOfExpiration { get; set; }

            [Display(Name = "Authority")]
            [StringLength(50)]
            public string Authority { get; set; } = default!;

            public string? AssignToUserId { get; set; }
        }
    }
}
