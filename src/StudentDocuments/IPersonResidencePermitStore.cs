namespace VisaManagement;

/// <summary>
/// Persistance of Person residence permit.
/// </summary>
public interface IPersonResidencePermitStore
{
    /// <summary>
    /// Gets queryable collection of Person residence permit.
    /// </summary>
    IQueryable<PersonResidencePermit> PersonResidencePermits { get; }

    /// <summary>
    /// Find by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<PersonResidencePermit?> FindByIdAsync(int id);

    /// <summary>
    /// Create.
    /// </summary>
    /// <param name="record"></param>
    /// <returns></returns>
    Task CreateAsync(PersonResidencePermit record);

    /// <summary>
    /// Update.
    /// </summary>
    /// <param name="record"></param>
    /// <returns></returns>
    Task UpdateAsync(PersonResidencePermit record);

    /// <summary>
    /// Delete.
    /// </summary>
    /// <param name="record"></param>
    /// <returns></returns>
    Task DeleteAsync(PersonResidencePermit record);
}
