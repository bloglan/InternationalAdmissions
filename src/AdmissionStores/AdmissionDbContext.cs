using Admissions;
using Microsoft.EntityFrameworkCore;

namespace AdmissionStores;
public class AdmissionDbContext(DbContextOptions<AdmissionDbContext> options) : DbContext(options)
{
    public DbSet<AdmissionPlan> AdmissionPlans { get; set; }

    public DbSet<Student> Students { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
