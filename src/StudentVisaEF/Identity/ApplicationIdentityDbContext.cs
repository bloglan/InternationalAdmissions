using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StudentVisaIdentity;

namespace StudentVisaEF.Identity;

public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //Rename table name.
        builder.Entity<ApplicationUser>().ToTable("ApplicationUser");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UserExternalLogin");
        builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
        builder.Entity<IdentityUserRole<string>>().ToTable("UserInRole");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");

        builder.Entity<IdentityRole>().ToTable("Role");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
    }
}