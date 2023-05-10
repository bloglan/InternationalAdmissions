using StudentDocuments;

namespace StudentDocumentStores;
public class PersonResidencePermitStore : IPersonResidencePermitStore
{
    private readonly StudentDocumentDbContext db;

    public PersonResidencePermitStore(StudentDocumentDbContext db)
    {
        this.db = db;
    }

    public IQueryable<PersonResidencePermit> PersonResidencePermits => this.db.PersonResidencePermits;

    public async Task CreateAsync(PersonResidencePermit record)
    {
        this.db.PersonResidencePermits.Add(record);
        await this.db.SaveChangesAsync();
    }

    public async Task DeleteAsync(PersonResidencePermit record)
    {
        this.db.PersonResidencePermits.Remove(record);
        await this.db.SaveChangesAsync();
    }

    public ValueTask<PersonResidencePermit?> FindByIdAsync(int id)
    {
        return this.db.PersonResidencePermits.FindAsync(id);
    }

    public async Task UpdateAsync(PersonResidencePermit record)
    {
        this.db.Entry(record).State = EntityState.Modified;
        await this.db.SaveChangesAsync();
    }
}
