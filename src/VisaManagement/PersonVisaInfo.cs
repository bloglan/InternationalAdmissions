namespace VisaManagement;

/// <summary>
/// VISA info.
/// </summary>
public class PersonVisaInfo
{
    /// <summary>
    /// VISA number.
    /// </summary>
    public string VisaNumber { get; set; } = default!;

    /// <summary>
    /// Category.
    /// </summary>
    public string Category { get; set; } = default!;

    /// <summary>
    /// Entries.
    /// </summary>
    public int Entries { get; set; }

    /// <summary>
    /// Enter before.
    /// </summary>
    public DateTime EnterBefore { get; set; }

    /// <summary>
    /// Duration of each stay.
    /// </summary>
    public int DurationOfEachStay { get; set; }

    /// <summary>
    /// Issue date.
    /// </summary>
    public DateTime IssueDate { get; set; }

    /// <summary>
    /// Issued at.
    /// </summary>
    public string IssuedAt { get; set; } = default!;

    /// <summary>
    /// Full name.
    /// </summary>
    public string FullName { get; set; } = default!;

    /// <summary>
    /// Birth date.
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Passport number.
    /// </summary>
    public string PassportNumber { get; set; } = default!;

    /// <summary>
    /// Remarks.
    /// </summary>
    public string? Remarks { get; set; }
}