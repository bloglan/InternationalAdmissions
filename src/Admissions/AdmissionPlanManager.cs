namespace Admissions;

/// <summary>
/// 
/// </summary>
/// <param name="store"></param>
public class AdmissionPlanManager(IQueryableAdmissionPlanStore store)
{
    /// <summary>
    /// 
    /// </summary>
    public IQueryable<AdmissionPlan> VisiblePlans => store.AdmissionPlans.Where(p => p.PublishTime.HasValue && p.Visible);
}
