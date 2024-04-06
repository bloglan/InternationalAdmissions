namespace StudentDocuments;

/// <summary>
/// VISA manager.
/// </summary>
/// <remarks>
/// Ctor.
/// </remarks>
/// <param name="store"></param>
public class VisaManager(IPersonVisaStore store)
{

    /// <summary>
    /// Gets VISAs.
    /// </summary>
    public IQueryable<PersonVisa> Visas => store.PersonVisas;

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
        await store.CreateAsync(visa);
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
        await store.UpdateAsync(visa);
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
        await store.DeleteAsync(visa);
        return OperationResult.Success;
    }

    /// <summary>
    /// Find VISA on passport.
    /// </summary>
    /// <param name="passportNumber"></param>
    /// <returns></returns>
    public IEnumerable<PersonVisa> FindByPassportNumber(string passportNumber)
    {
        return store.PersonVisas.Where(p => p.Visa.PassportNumber == passportNumber);
    }

    /// <summary>
    /// Find Person visa by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ValueTask<PersonVisa?> FindByIdAsync(int id)
    {
        return store.FindByIdAsync(id);
    }
}
