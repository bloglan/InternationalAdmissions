using System.Security.Claims;

namespace StudentDocuments;

/// <summary>
/// Extensions for queryable passport.
/// </summary>
public static class QueryableVisaExtensions
{
    /// <summary>
    /// Gets Owned by
    /// </summary>
    /// <param name="queryable"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public static IQueryable<PersonVisa> OwnedBy(this IQueryable<PersonVisa> queryable, ClaimsPrincipal user)
    {
        var userId = user.UserId();
        if (userId == null)
            return Array.Empty<PersonVisa>().AsQueryable();
        return queryable.Where(p => p.Owner!.Id == userId);
    }

    /// <summary>
    /// Managed by.
    /// </summary>
    /// <param name="queryable"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public static IQueryable<PersonVisa> ManagedBy(this IQueryable<PersonVisa> queryable, ClaimsPrincipal user)
    {
        var userId = user.UserId();
        if (userId == null)
            return Array.Empty<PersonVisa>().AsQueryable();
        return queryable.Where(p => p.Manager.Id == userId);
    }
}
