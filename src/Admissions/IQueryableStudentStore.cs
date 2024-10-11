namespace Admissions;

/// <summary>
/// 
/// </summary>
public interface IQueryableStudentStore
{
    /// <summary>
    /// 
    /// </summary>
    IQueryable<Student> Students { get; }
}
