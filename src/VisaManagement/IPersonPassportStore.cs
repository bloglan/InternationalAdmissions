namespace VisaManagement;

/// <summary>
/// Support Person passport info persistance.
/// </summary>
public interface IPersonPassportStore
{
    /// <summary>
    /// Gets queryable collection of passport.
    /// </summary>
    IQueryable<PersonPassport> Passports { get; }

    /// <summary>
    /// Create passport.
    /// </summary>
    /// <param name="passport"></param>
    /// <returns></returns>
    Task CreateAsync(PersonPassport passport);

    /// <summary>
    /// Update passport.
    /// </summary>
    /// <param name="passport"></param>
    /// <returns></returns>
    Task UpdateAsync(PersonPassport passport);

    /// <summary>
    /// Delete passport.
    /// </summary>
    /// <param name="passport"></param>
    /// <returns></returns>
    Task DeleteAsync(PersonPassport passport);

    /// <summary>
    /// Find passport by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<PersonPassport?> FindByIdAsync(int id);
}
