using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StudentVisaIdentity;

namespace StudentVisaEF;

public class ApplicationUserStore : UserStore<ApplicationUser, IdentityRole, ApplicationIdentityDbContext>
{
    public ApplicationUserStore(ApplicationIdentityDbContext context, IdentityErrorDescriber? describer = null) : base(context, describer)
    {
    }
}
