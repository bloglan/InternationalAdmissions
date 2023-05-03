using System.Security.Claims;

namespace VisaManagement;

/// <summary>
/// Extensions for queryable passport.
/// </summary>
public static class QueryablePassportExtensions
{
    /// <summary>
    /// Gets Owned by
    /// </summary>
    /// <param name="queryable"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public static IQueryable<PersonPassport> OwnedBy(this IQueryable<PersonPassport> queryable, ClaimsPrincipal user)
    {
        var userId = user.UserId();
        if (userId == null)
            return Array.Empty<PersonPassport>().AsQueryable();
        return queryable.Where(p => p.Owner!.Id == userId);
    }

    /// <summary>
    /// Managed by.
    /// </summary>
    /// <param name="queryable"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public static IQueryable<PersonPassport> ManagedBy(this IQueryable<PersonPassport> queryable, ClaimsPrincipal user)
    {
        var userId = user.UserId();
        if (userId == null)
            return Array.Empty<PersonPassport>().AsQueryable();
        return queryable.Where(p => p.Manager.Id == userId);
    }
}
