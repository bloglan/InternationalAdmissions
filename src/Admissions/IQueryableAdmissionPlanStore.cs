namespace Admissions;

/// <summary>
/// 
/// </summary>
public interface IQueryableAdmissionPlanStore
{
    /// <summary>
    /// 
    /// </summary>
    IQueryable<AdmissionPlan> AdmissionPlans { get; }
}
