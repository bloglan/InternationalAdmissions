using StudentDocumentStores;

namespace DatabaseTool.Migrators;
internal class StudentDocumentMigrator(StudentDocumentDbContext dbContext) :DatabaseMigrator(dbContext)
{
}
