namespace StudentDocuments;

/// <summary>
/// Residence permit manager.
/// </summary>
/// <remarks>
/// Ctor.
/// </remarks>
/// <param name="personResidencePermitStore"></param>
public class ResidencePermitManager(IPersonResidencePermitStore personResidencePermitStore)
{

    /// <summary>
    /// Gets queryable of permits.
    /// </summary>
    public IQueryable<PersonResidencePermit> Permits => personResidencePermitStore.PersonResidencePermits;

    /// <summary>
    /// Find by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ValueTask<PersonResidencePermit?> FindByIdAsync(int id)
    {
        return personResidencePermitStore.FindByIdAsync(id);
    }
}
