using System.ComponentModel.DataAnnotations.Schema;

namespace VisaManagement;

[Table("PersonVisa")]
public class PersonVisa
{
    public int Id { get; set; }

    public virtual PersonInfo Owner { get; set; }

    public virtual VisaInfo Visa { get; set; }

    public virtual PersonInfo Manager { get; set; }

    public DateTime WhenCreated { get; set; } = DateTime.UtcNow;

    public DateTime WhenChanged { get; set; } = DateTime.UtcNow;
}
