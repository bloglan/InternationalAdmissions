using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisaManagement;

/// <summary>
/// Passport info.
/// </summary>
[Owned]
public class PersonPassportInfo
{
    /// <summary>
    /// Type
    /// </summary>
    [MaxLength(10), Unicode(false)]
    public string Type { get; set; } = default!;

    /// <summary>
    /// Country code.
    /// </summary>
    [MaxLength(10), Unicode(false)]
    public string CountryCode { get; set; } = default!;

    /// <summary>
    /// Passport number.
    /// </summary>
    [Column(TypeName = "char(9)")]
    public string PassportNumber { get; set; } = default!;

    /// <summary>
    /// Surname.
    /// </summary>
    [MaxLength(20)]
    public string Surname { get; set; } = default!;

    /// <summary>
    /// Given name.
    /// </summary>
    [MaxLength(20)]
    public string GivenName { get; set; } = default!;

    /// <summary>
    /// Sex.
    /// </summary>
    [MaxLength(10), Unicode(false)]
    public string Sex { get; set; } = default!;

    /// <summary>
    /// Nationality.
    /// </summary>
    [MaxLength(50)]
    public string Nationality { get; set; } = default!;

    /// <summary>
    /// Date of birth.
    /// </summary>
    [Column(TypeName = "date")]
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Place of birth.
    /// </summary>
    [MaxLength(50)]
    public string PlaceOfBirth { get; set; } = default!;

    /// <summary>
    /// Date of issue.
    /// </summary>
    [Column(TypeName = "date")]
    public DateTime DateOfIssue { get; set; }

    /// <summary>
    /// Date of expiration.
    /// </summary>
    [Column(TypeName = "date")]
    public DateTime DateOfExpiration { get; set; }

    /// <summary>
    /// Authority.
    /// </summary>
    [MaxLength(50)]
    public string Authority { get; set; } = default!;
}
