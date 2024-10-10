using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace PersonIdentity;

/// <summary>
/// 
/// </summary>
/// <remarks>
/// 
/// </remarks>
/// <param name="userManager"></param>
/// <param name="roleManager"></param>
/// <param name="options"></param>
public class PersonClaimsFactory(UserManager<Person> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : UserClaimsPrincipalFactory<Person, IdentityRole>(userManager, roleManager, options)
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Person user)
    {
        var identity = await base.GenerateClaimsAsync(user);
        //移除默认的Name声明。
        var anyNameClaims = identity.FindAll(ClaimTypes.Name).ToList();
        foreach (var anyNameClaim in anyNameClaims) { identity.RemoveClaim(anyNameClaim); }
        //用 user.Name发出Name声明。
        identity.AddClaim(new Claim(Options.ClaimsIdentity.UserNameClaimType, user.Name));
        return identity;
    }

}
