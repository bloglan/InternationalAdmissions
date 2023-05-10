using System.ComponentModel.DataAnnotations.Schema;

namespace StudentDocuments;

/// <summary>
/// 居留许可
/// </summary>
[Table("PersonResidencePermit")]
public class PersonResidencePermit
{
    /// <summary>
    /// Key
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Owner.
    /// </summary>
    public PersonInfo? Owner { get; set; }

    /// <summary>
    /// Manager.
    /// </summary>
    public PersonInfo Manager { get; set; } = default!;

    /// <summary>
    /// Residence permit.
    /// </summary>
    public ResidencePermitInfo ResidencePermit { get; set; } = default!;

    /// <summary>
    /// Create time.
    /// </summary>
    public DateTime WhenCreated { get; set; }

    /// <summary>
    /// Update time.
    /// </summary>
    public DateTime WhenChanged { get; set; }
}
