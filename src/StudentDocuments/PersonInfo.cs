using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
    [MaxLength(50), Unicode(false)]
    public string Id { get; set; } = default!;

    /// <summary>
    /// Name.
    /// </summary>
    [MaxLength(50)]
    public string Name { get; set; } = default!;
}
