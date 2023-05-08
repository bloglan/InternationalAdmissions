using VisaManagement;

namespace StudentDocumentStores;
public class PersonVisaStore : IPersonVisaStore
{
    private readonly StudentDocumentDbContext dbContext;

    public PersonVisaStore(StudentDocumentDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IQueryable<PersonVisa> PersonVisas => this.dbContext.Visas;

    public async Task CreateAsync(PersonVisa personVisa)
    {
        this.dbContext.Visas.Add(personVisa);
        await this.dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(PersonVisa personVisa)
    {
        this.dbContext.Visas.Remove(personVisa);
        await this.dbContext.SaveChangesAsync();
    }

    public ValueTask<PersonVisa?> FindByIdAsync(int id)
    {
        return this.dbContext.Visas.FindAsync(id);
    }

    public async Task UpdateAsync(PersonVisa personVisa)
    {
        this.dbContext.Entry(personVisa).State = EntityState.Modified;
        await this.dbContext.SaveChangesAsync();
    }
}
