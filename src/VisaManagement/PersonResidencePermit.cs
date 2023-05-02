using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisaManagement;

/// <summary>
/// 居留许可
/// </summary>
[Table("PersonResidencePermit")]
public class PersonResidencePermit
{
    public int Id { get; set; }

    public PersonInfo? Owner { get; set; }

    public PersonInfo Manager { get; set; }

    public ResidencePermitInfo ResidencePermit { get; set; }

    public DateTime WhenCreated { get; set; }

    public DateTime WhenChanged { get; set; }
}
