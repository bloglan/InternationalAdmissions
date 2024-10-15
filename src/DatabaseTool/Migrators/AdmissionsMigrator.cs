using AdmissionStores;

namespace DatabaseTool.Migrators;
internal class AdmissionsMigrator(AdmissionDbContext dbContext) :DatabaseMigrator(dbContext)
{
}
