using PersonIdentityStores;

namespace DatabaseTool.Migrators;
internal class PersonIdentityMigrator(PersonIdentityDbContext dbContext) :DatabaseMigrator(dbContext)
{
}
