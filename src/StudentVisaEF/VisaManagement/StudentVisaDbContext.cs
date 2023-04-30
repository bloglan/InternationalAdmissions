using VisaManagement;

namespace StudentVisaEF.VisaManagement;
public class StudentVisaDbContext : DbContext
{
    public StudentVisaDbContext(DbContextOptions<StudentVisaDbContext> options) : base(options)
    {
    }

    public DbSet<PersonPassport> Passports { get; protected set; }

    public DbSet<PersonVisa> Visas { get; protected set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
