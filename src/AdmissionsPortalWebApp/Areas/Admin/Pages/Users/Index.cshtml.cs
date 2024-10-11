using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonIdentity;

namespace AdmissionsPortalWebApp.Areas.Admin.Pages.Users;

public class IndexModel(UserManager<ApplicationUser> userManager) : PageModel
{

    public IEnumerable<ApplicationUser> Users { get; set; } = [];
    public void OnGet(string? q)
    {
        IQueryable<ApplicationUser> users = userManager.Users;
        if (!string.IsNullOrEmpty(q))
        {
            users = users.Where(u => u.UserName!.Contains(q) || u.Email!.Contains(q) || u.Name.Contains(q));
        }
        Users = users;
    }
}
