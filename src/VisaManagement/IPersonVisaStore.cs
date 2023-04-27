namespace VisaManagement;
public interface IPersonVisaStore
{
    IQueryable<PersonVisa> PersonVisas { get; }

    Task CreateAsync(PersonVisa personVisa);

    Task UpdateAsync(PersonVisa personVisa);

    Task DeleteAsync(PersonVisa personVisa);
}
