using System.ComponentModel.DataAnnotations.Schema;

namespace VisaManagement;

/// <summary>
/// Passport
/// </summary>
[Table("PersonPassport")]
public class PersonPassport
{
    /// <summary>
    /// Id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Owner.
    /// </summary>
    public virtual PersonInfo? Owner { get; set; }

    /// <summary>
    /// Passport info.
    /// </summary>
    public virtual PersonPassportInfo Passport { get; set; } = default!;

    /// <summary>
    /// Manager.
    /// </summary>
    public virtual PersonInfo Manager { get; set; } = default!;

    /// <summary>
    /// Create time.
    /// </summary>
    public DateTime WhenCreated { get; set; }

    /// <summary>
    /// Update time.
    /// </summary>
    public DateTime WhenChanged { get; set; }
}
