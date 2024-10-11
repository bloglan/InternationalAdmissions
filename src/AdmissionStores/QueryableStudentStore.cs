using Admissions;

namespace AdmissionStores;

public class QueryableStudentStore(AdmissionDbContext dbContext) : IQueryableStudentStore
{
    public IQueryable<Student> Students => dbContext.Students;
}
