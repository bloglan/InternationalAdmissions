﻿namespace VisaManagement;

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
}
