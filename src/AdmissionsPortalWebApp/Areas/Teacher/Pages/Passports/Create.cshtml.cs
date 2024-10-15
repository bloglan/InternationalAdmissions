using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentDocuments;
using System.ComponentModel.DataAnnotations;

namespace AdmissionsPortalWebApp.Areas.Teacher.Pages.Passports;

public class CreateModel(PassportManager passportManager) : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        PersonPassport passport = new()
        {
            Passport = new()
            {
                Type = Input.Type,
                CountryCode = Input.CountryCode,
                PassportNumber = Input.PassportNumber,
                Surname = Input.Surname,
                GivenName = Input.GivenName,
                Sex = Input.Sex,
                Nationality = Input.Nationality,
                DateOfBirth = Input.DateOfBirth,
                PlaceOfBirth = Input.PlaceOfBirth,
                DateOfIssue = Input.DateOfIssue,
                DateOfExpiration = Input.DateOfExpiration,
                Authority = Input.Authority,
            },
            Manager = new()
            {
                Id = User.UserId()!,
                Name = User.Identity!.Name!,
            },
        };
        var result = await passportManager.CreateAsync(passport);
        if (result.IsSuccess)
        {
            return RedirectToPage("Index");
        }

        foreach (string error in result.Errors)
        {
            ModelState.AddModelError("", error);
        }
        return Page();
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
        [StringLength(9, MinimumLength = 9)]
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
