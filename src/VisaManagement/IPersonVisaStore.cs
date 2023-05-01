namespace VisaManagement;

/// <summary>
/// Support VISA persistance.
/// </summary>
public interface IPersonVisaStore
{
    /// <summary>
    /// Gets queryable collection of VISA.
    /// </summary>
    IQueryable<PersonVisa> PersonVisas { get; }

    /// <summary>
    /// Create VISA.
    /// </summary>
    /// <param name="personVisa"></param>
    /// <returns></returns>
    Task CreateAsync(PersonVisa personVisa);

    /// <summary>
    /// Update VISA.
    /// </summary>
    /// <param name="personVisa"></param>
    /// <returns></returns>
    Task UpdateAsync(PersonVisa personVisa);

    /// <summary>
    /// Delete VISA.
    /// </summary>
    /// <param name="personVisa"></param>
    /// <returns></returns>
    Task DeleteAsync(PersonVisa personVisa);

    /// <summary>
    /// Find Person Visa info by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<PersonVisa?> FindByIdAsync(int id);
}
