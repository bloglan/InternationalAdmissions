using VisaManagement;

namespace StudentVisaEF.VisaManagement;
public class PersonPassportStore : IPersonPassportStore
{
    private readonly StudentVisaDbContext dbContext;

    public PersonPassportStore(StudentVisaDbContext dbContext)
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

    public async Task UpdateAsync(PersonPassport passport)
    {
        this.dbContext.Entry(passport).State = EntityState.Modified;
        await this.dbContext.SaveChangesAsync();
    }
}
