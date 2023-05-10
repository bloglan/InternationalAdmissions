using System.Security.Claims;

namespace StudentDocuments;

/// <summary>
/// Extensions for queryable passport.
/// </summary>
public static class QueryableResidencePermitExtensions
{
    /// <summary>
    /// Gets Owned by
    /// </summary>
    /// <param name="queryable"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public static IQueryable<PersonResidencePermit> OwnedBy(this IQueryable<PersonResidencePermit> queryable, ClaimsPrincipal user)
    {
        var userId = user.UserId();
        if (userId == null)
            return Array.Empty<PersonResidencePermit>().AsQueryable();
        return queryable.Where(p => p.Owner!.Id == userId);
    }

    /// <summary>
    /// Managed by.
    /// </summary>
    /// <param name="queryable"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public static IQueryable<PersonResidencePermit> ManagedBy(this IQueryable<PersonResidencePermit> queryable, ClaimsPrincipal user)
    {
        var userId = user.UserId();
        if (userId == null)
            return Array.Empty<PersonResidencePermit>().AsQueryable();
        return queryable.Where(p => p.Manager.Id == userId);
    }
}
