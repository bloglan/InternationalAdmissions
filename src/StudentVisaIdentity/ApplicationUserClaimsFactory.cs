using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace StudentVisaIdentity;

/// <summary>
/// 
/// </summary>
public class ApplicationUserClaimsFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userManager"></param>
    /// <param name="roleManager"></param>
    /// <param name="options"></param>
    public ApplicationUserClaimsFactory(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
    {
        var identity = await base.GenerateClaimsAsync(user);
        //remove name claim
        var anyNameClaims = identity.FindAll(ClaimTypes.Name).ToList();
        foreach (var anyNameClaim in anyNameClaims) { identity.RemoveClaim(anyNameClaim); }
        identity.AddClaim(new Claim(this.Options.ClaimsIdentity.UserNameClaimType, user.Name));
        return identity;
    }

}
