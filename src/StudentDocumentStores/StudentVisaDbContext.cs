using VisaManagement;

namespace StudentDocumentStores;
public class StudentVisaDbContext : DbContext
{
    public StudentVisaDbContext(DbContextOptions<StudentVisaDbContext> options) : base(options)
    {
    }

    public DbSet<PersonPassport> Passports { get; protected set; }

    public DbSet<PersonVisa> Visas { get; protected set; }

    public DbSet<PersonResidencePermit> PersonResidencePermits { get; protected set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
