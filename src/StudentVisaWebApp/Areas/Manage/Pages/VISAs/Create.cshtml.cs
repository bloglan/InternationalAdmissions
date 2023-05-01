using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using VisaManagement;

namespace StudentVisaWebApp.Areas.Manage.Pages.VISAs;

public class CreateModel : PageModel
{
    private readonly VisaManager visaManager;
    private readonly PassportManager passportManager;

    public CreateModel(VisaManager visaManager, PassportManager passportManager)
    {
        this.visaManager = visaManager;
        this.passportManager = passportManager;
    }

    [BindProperty]
    public InputModel Input { get; set; } = default!;

    public void OnGet(string? passport)
    {
        if (passport != null)
        {
            var personPassport = this.passportManager.FindByPassportNumber(passport);
            if (personPassport != null)
            {
                this.Input = new InputModel()
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
        if (!this.ModelState.IsValid)
            return this.Page();

        PersonVisa visa = new()
        {
            Visa = new()
            {
                VisaNumber = this.Input.VisaNumber,
                Category = this.Input.Category,
                Entries = this.Input.Entries,
                EnterBefore = this.Input.EnterBefore,
                DurationOfEachStay = this.Input.DurationOfEachStay,
                IssueDate = this.Input.IssueDate,
                IssuedAt = this.Input.IssuedAt,
                FullName = this.Input.FullName,
                BirthDate = this.Input.BirthDate,
                PassportNumber = this.Input.PassportNumber,
                Remarks = this.Input.Remarks,
            },
            Manager = new()
            {
                Id = this.User.UserId()!,
                Name = this.User.Identity!.Name!,
            },
        };

        var result = await this.visaManager.CreateAsync(visa);
        if (result.IsSuccess)
            return this.RedirectToPage("Detail", new { id = visa.Id });

        foreach (var err in result.Errors)
        {
            this.ModelState.AddModelError("", err);
        }
        return this.Page();
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
        public DateTime EnterBefore { get; set; } = new DateTime(DateTime.UtcNow.Year, 12, 31);

        [Display(Name = "Duration Of Each Stay")]
        public int DurationOfEachStay { get; set; } = 30;

        [Display(Name = "Issue Date")]
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; } = new DateTime(DateTime.UtcNow.Year, 1, 1);

        [Display(Name = "Issued At")]
        [StringLength(50)]
        public string IssuedAt { get; set; } = default!;

        [Display(Name = "Full Name")]
        [StringLength(40)]
        public string FullName { get; set; } = default!;

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; } = new DateTime(2000, 1, 1);

        [Display(Name = "Passport Number")]
        [StringLength(9, MinimumLength = 9)]
        public string PassportNumber { get; set; } = default!;

        [Display(Name = "Remarks")]
        [StringLength(50)]
        public string Remarks { get; set; } = default!;

        [Display(Name = "AssignToUserId")]
        public string? AssignToUserId { get; set; }
    }
}