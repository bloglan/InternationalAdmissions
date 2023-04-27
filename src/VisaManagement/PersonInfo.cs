using Microsoft.EntityFrameworkCore;

namespace VisaManagement;

[Owned]
public class PersonInfo
{
    public string Id { get; set; }

    public string Name { get; set; }
}
