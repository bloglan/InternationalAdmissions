namespace VisaManagement;

/// <summary>
/// Residence permit manager.
/// </summary>
public class ResidencePermitManager
{
    private readonly IPersonResidencePermitStore personResidencePermitStore;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="personResidencePermitStore"></param>
    public ResidencePermitManager(IPersonResidencePermitStore personResidencePermitStore)
    {
        this.personResidencePermitStore = personResidencePermitStore;
    }

    /// <summary>
    /// Gets queryable of permits.
    /// </summary>
    public IQueryable<PersonResidencePermit> Permits => this.personResidencePermitStore.PersonResidencePermits;

    /// <summary>
    /// Find by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ValueTask<PersonResidencePermit?> FindByIdAsync(int id)
    {
        return this.personResidencePermitStore.FindByIdAsync(id);
    }
}
