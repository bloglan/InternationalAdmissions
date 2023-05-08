using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisaManagement;

/// <summary>
/// Residence permit info.
/// </summary>
[Owned]
public class ResidencePermitInfo
{
    /// <summary>
    /// Number.
    /// </summary>
    [MaxLength(9), Unicode(false)]
    public string Number { get; set; } = default!;

    /// <summary>
    /// Full name.
    /// </summary>
    [MaxLength(40)]
    public string FullName { get; set; } = default!;

    /// <summary>
    /// Sex.
    /// </summary>
    [MaxLength(10), Unicode(false)]
    public string Sex { get; set; } = default!;

    /// <summary>
    /// Date of birth.
    /// </summary>
    [Column(TypeName = "date")]
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Passport number.
    /// </summary>
    [Column(TypeName = "char(9)")]
    public string PassportNumber { get; set; } = default!;

    /// <summary>
    /// Purpose for residence.
    /// </summary>
    [MaxLength(10)]
    public string PurposeForResidence { get; set; } = default!;

    /// <summary>
    /// Valid for residence until.
    /// </summary>
    [Column(TypeName = "date")]
    public DateTime ValidForResidenceUntil { get; set; }

    /// <summary>
    /// Date of issue.
    /// </summary>
    [Column(TypeName = "date")]
    public DateTime DateOfIssue { get; set; }

    /// <summary>
    /// Place of issue.
    /// </summary>
    [MaxLength(20)]
    public string PlaceOfIssue { get; set; } = default!;

    /// <summary>
    /// Observations.
    /// </summary>
    [MaxLength(50)]
    public string? Observations { get; set; }
}