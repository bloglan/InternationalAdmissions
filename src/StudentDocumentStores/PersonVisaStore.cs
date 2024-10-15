using StudentDocuments;

namespace StudentDocumentStores;
public class PersonVisaStore(StudentDocumentDbContext dbContext) : IPersonVisaStore
{
    public IQueryable<PersonVisa> PersonVisas => dbContext.Visas;

    public async Task CreateAsync(PersonVisa personVisa)
    {
        dbContext.Visas.Add(personVisa);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(PersonVisa personVisa)
    {
        dbContext.Visas.Remove(personVisa);
        await dbContext.SaveChangesAsync();
    }

    public ValueTask<PersonVisa?> FindByIdAsync(int id)
    {
        return dbContext.Visas.FindAsync(id);
    }

    public async Task UpdateAsync(PersonVisa personVisa)
    {
        dbContext.Entry(personVisa).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
    }
}
