using Admissions;

namespace AdmissionStores;
public class QueryableAdmissionPlanStore(AdmissionDbContext dbContext) : IQueryableAdmissionPlanStore
{

    public IQueryable<AdmissionPlan> AdmissionPlans => dbContext.AdmissionPlans;
}
