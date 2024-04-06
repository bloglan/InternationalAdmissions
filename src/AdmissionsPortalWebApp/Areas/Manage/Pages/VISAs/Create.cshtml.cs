using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentDocuments;
using System.ComponentModel.DataAnnotations;

namespace AdmissionsPortalWebApp.Areas.Manage.Pages.VISAs;

public class CreateModel(VisaManager visaManager, PassportManager passportManager) : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public void OnGet(string? passport)
    {
        if (passport != null)
        {
            var personPassport = passportManager.FindByPassportNumber(passport);
            if (personPassport != null)
            {
                Input = new InputModel()
                {
                    PassportNumber = personPassport.Passport.PassportNumber,
                    BirthDate = personPassport.Passport.DateOfBirth,
                    FullName = $"{personPassport.Passport.GivenName} {personPassport.Passport.Surname}".Trim(),
                };
            }
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        PersonVisa visa = new()
        {
            Visa = new()
            {
                VisaNumber = Input.VisaNumber,
                Category = Input.Category,
                Entries = Input.Entries,
                EnterBefore = Input.EnterBefore,
                DurationOfEachStay = Input.DurationOfEachStay,
                IssueDate = Input.IssueDate,
                IssuedAt = Input.IssuedAt,
                FullName = Input.FullName,
                BirthDate = Input.BirthDate,
                PassportNumber = Input.PassportNumber,
                Remarks = Input.Remarks,
            },
            Manager = new()
            {
                Id = User.UserId()!,
                Name = User.Identity!.Name!,
            },
        };

        var result = await visaManager.CreateAsync(visa);
        if (result.IsSuccess)
            return RedirectToPage("Detail", new { id = visa.Id });

        foreach (var err in result.Errors)
        {
            ModelState.AddModelError("", err);
        }
        return Page();
    }

    public class InputModel
    {
        [Display(Name = "Visa Number")]
        [StringLength(32)]
        public string VisaNumber { get; set; } = default!;

        [Display(Name = "Category")]
        [StringLength(10)]
        public string Category { get; set; } = default!;

        [Display(Name = "Entries")]
        public int Entries { get; set; } = 1;

        [Display(Name = "Enter Before")]
        [DataType(DataType.Date)]
        public DateTime EnterBefore { get; set; } = new(DateTime.UtcNow.Year, 12, 31);

        [Display(Name = "Duration Of Each Stay")]
        public int DurationOfEachStay { get; set; } = 30;

        [Display(Name = "Issue Date")]
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; } = new(DateTime.UtcNow.Year, 1, 1);

        [Display(Name = "Issued At")]
        [StringLength(50)]
        public string IssuedAt { get; set; } = default!;

        [Display(Name = "Full Name")]
        [StringLength(40)]
        public string FullName { get; set; } = default!;

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; } = new(2000, 1, 1);

        [Display(Name = "Passport Number")]
        [StringLength(9, MinimumLength = 9)]
        public string PassportNumber { get; set; } = default!;

        [Display(Name = "Remarks")]
        [StringLength(50)]
        public string? Remarks { get; set; }

        [Display(Name = "AssignToUserId")]
        public string? AssignToUserId { get; set; }
    }
}