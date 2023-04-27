using Microsoft.EntityFrameworkCore;

namespace VisaManagement;

[Owned]
public class PassportInfo
{
    public string Type { get; set; }

    public string CountryCode { get; set; }

    public string PassportNumber { get; set; }

    public string Surname { get; set; }

    public string GivenName { get; set; }

    public string Sex { get; set; }

    public string Nationality { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string PlaceOfBirth { get; set; }

    public DateTime DateOfIssue { get; set; }

    public DateTime DateOfExpiration { get; set; }

    public string Authority { get; set; }
}
