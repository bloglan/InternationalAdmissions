using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admissions;

/// <summary>
/// 学生信息
/// </summary>
[Table("Student")]
public class Student
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// 关联招生计划Id
    /// </summary>
    public int AdmissionPlanId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [ForeignKey(nameof(AdmissionPlanId))]
    public virtual AdmissionPlan AdmissionPlan { get; set; } = default!;

    /// <summary>
    /// 学生名字
    /// </summary>
    [MaxLength(50)]
    public string Name { get; set; } = default!;


}
