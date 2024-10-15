using StudentDocuments;

namespace StudentDocumentStores;
public class StudentDocumentDbContext(DbContextOptions<StudentDocumentDbContext> options) : DbContext(options)
{
    public DbSet<PersonPassport> Passports { get; protected set; }

    public DbSet<PersonVisa> Visas { get; protected set; }

    public DbSet<PersonResidencePermit> PersonResidencePermits { get; protected set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
