namespace VisaManagement;

/// <summary>
/// VISA manager.
/// </summary>
public class VisaManager
{
    private readonly IPersonVisaStore personVisaStore;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="store"></param>
    public VisaManager(IPersonVisaStore store)
    {
        this.personVisaStore = store;
    }

    /// <summary>
    /// Gets VISAs.
    /// </summary>
    public IQueryable<PersonVisa> Visas => this.personVisaStore.PersonVisas;

    /// <summary>
    /// Create VISA.
    /// </summary>
    /// <param name="visa"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<OperationResult> CreateAsync(PersonVisa visa)
    {
        await this.personVisaStore.CreateAsync(visa);
        throw new NotImplementedException();
    }

    /// <summary>
    /// Update VISA.
    /// </summary>
    /// <param name="visa"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<OperationResult> UpdateAsync(PersonVisa visa)
    {
        visa.WhenChanged = DateTime.UtcNow;
        await this.personVisaStore.UpdateAsync(visa);
        throw new NotImplementedException();
    }

    /// <summary>
    /// Delete VISA.
    /// </summary>
    /// <param name="visa"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<OperationResult> DeleteAsync(PersonVisa visa)
    {
        await this.personVisaStore.DeleteAsync(visa);
        throw new NotImplementedException();
    }
}
