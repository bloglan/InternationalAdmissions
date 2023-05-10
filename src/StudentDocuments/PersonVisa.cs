using System.ComponentModel.DataAnnotations.Schema;

namespace StudentDocuments;

/// <summary>
/// VISA.
/// </summary>
[Table("PersonVisa")]
public class PersonVisa
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
    /// VISA info.
    /// </summary>
    public virtual PersonVisaInfo Visa { get; set; } = default!;

    /// <summary>
    /// Manager.
    /// </summary>
    public virtual PersonInfo Manager { get; set; } = default!;

    /// <summary>
    /// Create time.
    /// </summary>
    public DateTime WhenCreated { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Update time.
    /// </summary>
    public DateTime WhenChanged { get; set; } = DateTime.UtcNow;
}
