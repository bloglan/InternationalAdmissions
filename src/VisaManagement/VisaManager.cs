namespace VisaManagement;
public class VisaManager
{
    private readonly IPersonVisaStore personVisaStore;

    public VisaManager(IPersonVisaStore store)
    {
        this.personVisaStore = store;
    }

    public async Task<OperationResult> CreateAsync(PersonVisa visa)
    {
        await this.personVisaStore.CreateAsync(visa);
        throw new NotImplementedException();
    }

    public async Task<OperationResult> UpdateAsync(PersonVisa visa)
    {
        visa.WhenChanged = DateTime.UtcNow;
        await this.personVisaStore.UpdateAsync(visa);
        throw new NotImplementedException();
    }

    public async Task<OperationResult> DeleteAsync(PersonVisa visa)
    {
        await this.personVisaStore.DeleteAsync(visa);
        throw new NotImplementedException();
    }
}
