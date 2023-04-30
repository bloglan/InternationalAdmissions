using Microsoft.EntityFrameworkCore;

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
    public string Type { get; set; } = default!;

    /// <summary>
    /// Country code.
    /// </summary>
    public string CountryCode { get; set; } = default!;

    /// <summary>
    /// Passport number.
    /// </summary>
    public string PassportNumber { get; set; } = default!;

    /// <summary>
    /// Surname.
    /// </summary>
    public string Surname { get; set; } = default!;

    /// <summary>
    /// Given name.
    /// </summary>
    public string GivenName { get; set; } = default!;

    /// <summary>
    /// Sex.
    /// </summary>
    public string Sex { get; set; } = default!;

    /// <summary>
    /// Nationality.
    /// </summary>
    public string Nationality { get; set; } = default!;

    /// <summary>
    /// Date of birth.
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Place of birth.
    /// </summary>
    public string PlaceOfBirth { get; set; } = default!;

    /// <summary>
    /// Date of issue.
    /// </summary>
    public DateTime DateOfIssue { get; set; }

    /// <summary>
    /// Date of expiration.
    /// </summary>
    public DateTime DateOfExpiration { get; set; }

    /// <summary>
    /// Authority.
    /// </summary>
    public string Authority { get; set; } = default!;
}
