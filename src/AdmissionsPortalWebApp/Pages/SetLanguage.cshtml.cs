using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdmissionsPortalWebApp.Pages
{
    public class SetLanguageModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return this.Redirect(returnUrl);
        }
    }
}
