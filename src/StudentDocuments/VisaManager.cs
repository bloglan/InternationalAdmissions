namespace StudentDocuments;

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
        var utcNow = DateTime.UtcNow;
        visa.WhenCreated = utcNow;
        visa.WhenChanged = utcNow;
        await this.personVisaStore.CreateAsync(visa);
        return OperationResult.Success;
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
        return OperationResult.Success;
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
        return OperationResult.Success;
    }

    /// <summary>
    /// Find VISA on passport.
    /// </summary>
    /// <param name="passportNumber"></param>
    /// <returns></returns>
    public IEnumerable<PersonVisa> FindByPassportNumber(string passportNumber)
    {
        return this.personVisaStore.PersonVisas.Where(p => p.Visa.PassportNumber == passportNumber);
    }

    /// <summary>
    /// Find Person visa by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ValueTask<PersonVisa?> FindByIdAsync(int id)
    {
        return this.personVisaStore.FindByIdAsync(id);
    }
}
