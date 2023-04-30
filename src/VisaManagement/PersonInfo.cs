using Microsoft.EntityFrameworkCore;

namespace VisaManagement;

/// <summary>
/// Person info.
/// </summary>
[Owned]
public class PersonInfo
{
    /// <summary>
    /// Id.
    /// </summary>
    public string Id { get; set; } = default!;

    /// <summary>
    /// Name.
    /// </summary>
    public string Name { get; set; } = default!;
}
