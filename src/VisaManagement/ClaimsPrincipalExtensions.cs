using System.Security.Claims;

namespace VisaManagement;
public static class ClaimsPrincipalExtensions
{
    public static string? UserId(this ClaimsPrincipal principal)
    {
        return principal.FindFirst(p => p.Type == ClaimTypes.NameIdentifier)?.Value;
    }

}
