using System.Security.Claims;

namespace VisaManagement;

public static class QueryablePassportExtensions
{
    public static IQueryable<PersonPassport> OwnedBy(this IQueryable<PersonPassport> queryable, ClaimsPrincipal user)
    {
        var userId = user.UserId();
        if (userId == null)
            return Array.Empty<PersonPassport>().AsQueryable();
        return queryable.Where(p => p.Owner!.Id == userId);
    }

    public static IQueryable<PersonPassport> ManagedBy(this IQueryable<PersonPassport> queryable, ClaimsPrincipal user)
    {
        var userId = user.UserId();
        if (userId == null)
            return Array.Empty<PersonPassport>().AsQueryable();
        return queryable.Where(p => p.Manager.Id == userId);
    }
}
