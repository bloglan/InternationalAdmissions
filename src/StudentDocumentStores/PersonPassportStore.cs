using StudentDocuments;

namespace StudentDocumentStores;
public class PersonPassportStore(StudentDocumentDbContext dbContext) : IPersonPassportStore
{
    public IQueryable<PersonPassport> Passports => dbContext.Passports;

    public async Task CreateAsync(PersonPassport passport)
    {
        dbContext.Add(passport);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(PersonPassport passport)
    {
        dbContext.Remove(passport);
        await dbContext.SaveChangesAsync();
    }

    public ValueTask<PersonPassport?> FindByIdAsync(int id)
    {
        return dbContext.Passports.FindAsync(id);
    }

    public async Task UpdateAsync(PersonPassport passport)
    {
        dbContext.Entry(passport).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
    }
}
