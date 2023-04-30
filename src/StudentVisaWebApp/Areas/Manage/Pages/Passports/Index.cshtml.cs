using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VisaManagement;

namespace StudentVisaWebApp.Areas.Manage.Pages.Passports
{
    public class IndexModel : PageModel
    {
        readonly PassportManager passportManager;

        public IndexModel(PassportManager passportManager)
        {
            this.passportManager = passportManager;
        }

        public IEnumerable<PersonPassport> Passports { get; set; } = default!;

        public void OnGet(string? q)
        {
            var passports = this.passportManager.Passports.ManagedBy(this.User);
            if(!string.IsNullOrEmpty(q))
            {
                passports = passports.Where(p => p.Passport.PassportNumber == q
                || p.Passport.Surname.Contains(q)
                || p.Passport.GivenName.Contains(q));
            }

            this.Passports = passports;
        }
    }
}
