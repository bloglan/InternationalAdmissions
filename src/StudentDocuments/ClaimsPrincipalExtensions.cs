using System.Security.Claims;

namespace VisaManagement;

/// <summary>
/// Extensions for ClaimsPrincipal.
/// </summary>
public static class ClaimsPrincipalExtensions
{
    /// <summary>
    /// Get UserId from claim in type: http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier
    /// </summary>
    /// <param name="principal"></param>
    /// <returns></returns>
    public static string? UserId(this ClaimsPrincipal principal)
    {
        return principal.FindFirst(p => p.Type == ClaimTypes.NameIdentifier)?.Value;
    }

}
