using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentVisaIdentity;

/// <summary>
/// User info for this Web Application.
/// </summary>
public class Person : IdentityUser<string>
{
    /// <summary>
    /// 
    /// </summary>
    public Person()
    {
        this.Id = Guid.NewGuid().ToString().ToLower();
    }

    /// <summary>
    /// First name.
    /// </summary>
    [MaxLength(30)]
    public string? FirstName { get; set; }

    /// <summary>
    /// Middle name.
    /// </summary>
    [MaxLength(30)]
    public string? MiddleName { get; set; }

    /// <summary>
    /// Last name.
    /// </summary>
    [MaxLength(30)]
    public string? LastName { get; set; }

    /// <summary>
    /// Full name.
    /// </summary>
    [MaxLength(100)]
    public string Name { get; set; } = default!;

    /// <summary>
    /// Nick name.
    /// </summary>
    [MaxLength(50)]
    public string? NickName { get; set; }

    /// <summary>
    /// Locale
    /// </summary>
    [MaxLength(30), Unicode(false)]
    public string Locale { get; set; } = "zh-CN";

    /// <summary>
    /// Sex.
    /// </summary>
    [Column(TypeName = "varchar(10)")]
    public Sex? Sex { get; set; }

    /// <summary>
    /// Birth date.
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// When created.
    /// </summary>
    public DateTime WhenCreated { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// When changed.
    /// </summary>
    public DateTime WhenChanged { get; set; } = DateTime.UtcNow;

}
