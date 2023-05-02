using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisaManagement;

[Owned]
public class ResidencePermitInfo
{
    [MaxLength(9),Unicode(false)]
    public string Number { get; set; }

    [MaxLength(40)]
    public string FullName { get; set; }

    [MaxLength(10),Unicode(false)]
    public string Sex { get; set; }

    [Column(TypeName = "date")]
    public DateTime DateOfBirth { get; set; }

    [Column(TypeName ="char(9)")]
    public string PassportNumber { get; set; }

    [MaxLength(10)]
    public string PurposeForResidence { get; set; }

    [Column(TypeName = "date")]
    public DateTime ValidForResidenceUntil { get; set; }

    [Column(TypeName = "date")]
    public DateTime DateOfIssue { get; set; }

    [MaxLength(20)]
    public string PlaceOfIssue { get; set; }

    [MaxLength(50)]
    public string? Observations { get; set; }
}