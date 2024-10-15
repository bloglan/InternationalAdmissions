using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentDocuments;

/// <summary>
/// VISA info.
/// </summary>
[Owned]
public class PersonVisaInfo
{
    /// <summary>
    /// VISA number.
    /// </summary>
    [MaxLength(32), Unicode(false)]
    public string VisaNumber { get; set; } = default!;

    /// <summary>
    /// Category.
    /// </summary>
    [MaxLength(10), Unicode(false)]
    public string Category { get; set; } = default!;

    /// <summary>
    /// Entries.
    /// </summary>
    public int Entries { get; set; }

    /// <summary>
    /// Enter before.
    /// </summary>
    [Column(TypeName = "date")]
    public DateTime EnterBefore { get; set; }

    /// <summary>
    /// Duration of each stay.
    /// </summary>
    public int DurationOfEachStay { get; set; }

    /// <summary>
    /// Issue date.
    /// </summary>
    [Column(TypeName = "date")]
    public DateTime IssueDate { get; set; }

    /// <summary>
    /// Issued at.
    /// </summary>
    [MaxLength(50)]
    public string IssuedAt { get; set; } = default!;

    /// <summary>
    /// Full name.
    /// </summary>
    [MaxLength(40)]
    public string FullName { get; set; } = default!;

    /// <summary>
    /// Birthdate.
    /// </summary>
    [Column(TypeName = "date")]
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Passport number.
    /// </summary>
    [Column(TypeName = "char(9)")]
    public string PassportNumber { get; set; } = default!;

    /// <summary>
    /// Remarks.
    /// </summary>
    [MaxLength(50)]
    public string? Remarks { get; set; }
}