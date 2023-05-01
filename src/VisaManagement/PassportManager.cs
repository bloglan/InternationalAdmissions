namespace VisaManagement;

/// <summary>
/// Passport manager.
/// </summary>
public class PassportManager
{
    private readonly IPersonPassportStore personPassportStore;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="store"></param>
    public PassportManager(IPersonPassportStore store)
    {
        this.personPassportStore = store;
    }

    /// <summary>
    /// Gets passports.
    /// </summary>
    public IQueryable<PersonPassport> Passports => this.personPassportStore.Passports;

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
        await this.personPassportStore.CreateAsync(passport);
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
        await this.personPassportStore.UpdateAsync(passport);
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
        await this.personPassportStore.DeleteAsync(passport);
        return OperationResult.Success;
    }

    /// <summary>
    /// Find Person passport by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ValueTask<PersonPassport?> FindByIdAsync(int id)
    {
        return this.personPassportStore.FindByIdAsync(id);
    }

    /// <summary>
    /// Find Person passport by passport number.
    /// </summary>
    /// <param name="passport"></param>
    /// <returns></returns>
    public PersonPassport? FindByPassportNumber(string passport)
    {
        return this.personPassportStore.Passports.FirstOrDefault(p => p.Passport.PassportNumber == passport);
    }
}
