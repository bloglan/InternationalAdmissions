using VisaManagement;

namespace StudentDocumentStores;
public class StudentDocumentDbContext : DbContext
{
    public StudentDocumentDbContext(DbContextOptions<StudentDocumentDbContext> options) : base(options)
    {
    }

    public DbSet<PersonPassport> Passports { get; protected set; }

    public DbSet<PersonVisa> Visas { get; protected set; }

    public DbSet<PersonResidencePermit> PersonResidencePermits { get; protected set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
