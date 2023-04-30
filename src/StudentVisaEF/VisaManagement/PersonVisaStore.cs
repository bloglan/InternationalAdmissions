using VisaManagement;

namespace StudentVisaEF.VisaManagement;
public class PersonVisaStore : IPersonVisaStore
{
    private readonly StudentVisaDbContext dbContext;

    public PersonVisaStore(StudentVisaDbContext dbContext)
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

    public async Task UpdateAsync(PersonVisa personVisa)
    {
        this.dbContext.Entry(personVisa).State = EntityState.Modified;
        await this.dbContext.SaveChangesAsync();
    }
}
