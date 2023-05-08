using VisaManagement;

namespace StudentDocumentStores;
public class PersonPassportStore : IPersonPassportStore
{
    private readonly StudentDocumentDbContext dbContext;

    public PersonPassportStore(StudentDocumentDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IQueryable<PersonPassport> Passports => this.dbContext.Passports;

    public async Task CreateAsync(PersonPassport passport)
    {
        this.dbContext.Add(passport);
        await this.dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(PersonPassport passport)
    {
        this.dbContext.Remove(passport);
        await this.dbContext.SaveChangesAsync();
    }

    public ValueTask<PersonPassport?> FindByIdAsync(int id)
    {
        return this.dbContext.Passports.FindAsync(id);
    }

    public async Task UpdateAsync(PersonPassport passport)
    {
        this.dbContext.Entry(passport).State = EntityState.Modified;
        await this.dbContext.SaveChangesAsync();
    }
}
