namespace StudentDocuments;

/// <summary>
/// Passport manager.
/// </summary>
/// <remarks>
/// Ctor.
/// </remarks>
/// <param name="store"></param>
public class PassportManager(IPersonPassportStore store)
{

    /// <summary>
    /// Gets passports.
    /// </summary>
    public IQueryable<PersonPassport> Passports => store.Passports;

    /// <summary>
    /// Create passport.
    /// </summary>
    /// <param name="passport"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<OperationResult> CreateAsync(PersonPassport passport)
    {
        var now = DateTime.UtcNow;
        passport.WhenCreated = now;
        passport.WhenChanged = now;
        await store.CreateAsync(passport);
        return OperationResult.Success;
    }

    /// <summary>
    /// Update passport.
    /// </summary>
    /// <param name="passport"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<OperationResult> UpdateAsync(PersonPassport passport)
    {
        passport.WhenChanged = DateTime.UtcNow;
        await store.UpdateAsync(passport);
        return OperationResult.Success;
    }

    /// <summary>
    /// Delete passport.
    /// </summary>
    /// <param name="passport"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<OperationResult> DeleteAsync(PersonPassport passport)
    {
        await store.DeleteAsync(passport);
        return OperationResult.Success;
    }

    /// <summary>
    /// Find Person passport by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ValueTask<PersonPassport?> FindByIdAsync(int id)
    {
        return store.FindByIdAsync(id);
    }

    /// <summary>
    /// Find Person passport by passport number.
    /// </summary>
    /// <param name="passport"></param>
    /// <returns></returns>
    public PersonPassport? FindByPassportNumber(string passport)
    {
        return store.Passports.FirstOrDefault(p => p.Passport.PassportNumber == passport);
    }
}
