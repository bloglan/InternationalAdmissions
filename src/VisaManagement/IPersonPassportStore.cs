namespace VisaManagement;
public interface IPersonPassportStore
{
    IQueryable<PersonPassport> Passports { get; }

    Task CreateAsync(PersonPassport passport);

    Task UpdateAsync(PersonPassport passport);

    Task DeleteAsync(PersonPassport passport);
}
