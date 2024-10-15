using StudentDocuments;

namespace StudentDocumentStores;
public class PersonResidencePermitStore(StudentDocumentDbContext db) : IPersonResidencePermitStore
{
    public IQueryable<PersonResidencePermit> PersonResidencePermits => db.PersonResidencePermits;

    public async Task CreateAsync(PersonResidencePermit record)
    {
        db.PersonResidencePermits.Add(record);
        await db.SaveChangesAsync();
    }

    public async Task DeleteAsync(PersonResidencePermit record)
    {
        db.PersonResidencePermits.Remove(record);
        await db.SaveChangesAsync();
    }

    public ValueTask<PersonResidencePermit?> FindByIdAsync(int id)
    {
        return db.PersonResidencePermits.FindAsync(id);
    }

    public async Task UpdateAsync(PersonResidencePermit record)
    {
        db.Entry(record).State = EntityState.Modified;
        await db.SaveChangesAsync();
    }
}
