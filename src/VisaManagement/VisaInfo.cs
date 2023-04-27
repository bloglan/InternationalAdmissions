namespace VisaManagement;

public class VisaInfo
{
    public string VisaNumber { get; set; }

    public string Category { get; set; }

    public int Entries { get; set; }

    public DateTime EnterBefore { get; set; }

    public int DurationOfEachStay { get; set; }

    public DateTime IssueDate { get; set; }

    public string IssuedAt { get; set; }

    public string FullName { get; set; }

    public DateTime BirthDate { get; set; }

    public string PassportNumber { get; set; }

    public string Remarks { get; set; }
}