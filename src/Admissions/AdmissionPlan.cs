using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admissions;

/// <summary>
/// 招生计划
/// </summary>
[Table("AdmissionPlan")]
public class AdmissionPlan
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [MaxLength(100)]
    public string Name { get; set; } = default!;

    /// <summary>
    /// 描述
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTimeOffset WhenCreated { get; set; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// 发布时间。null表示未发布。
    /// </summary>
    public DateTimeOffset? PublishTime { get; set; }

    /// <summary>
    /// 是否可见。
    /// </summary>
    public bool Visible { get; set; } = true;

    /// <summary>
    /// 是否可申请。
    /// </summary>
    public bool CanRequest { get; set; } = true;
}
