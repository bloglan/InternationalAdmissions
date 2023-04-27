namespace VisaManagement;
public class PassportManager
{
    private readonly IPersonPassportStore personPassportStore;

    public PassportManager(IPersonPassportStore store)
    {
        this.personPassportStore = store;
    }

    public async Task<OperationResult> CreateAsync(PersonPassport passport)
    {
        await this.personPassportStore.CreateAsync(passport);
        throw new NotImplementedException();
    }

    public async Task<OperationResult> UpdateAsync(PersonPassport passport)
    {
        passport.WhenChanged = DateTime.UtcNow;
        await this.personPassportStore.UpdateAsync(passport);
        throw new NotImplementedException();
    }

    public async Task<OperationResult> DeleteAsync(PersonPassport passport)
    {
        await this.personPassportStore.DeleteAsync(passport);
        throw new NotImplementedException();
    }
}
