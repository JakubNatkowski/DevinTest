using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardDemo.Core.Entities;

/// <summary>
/// User entity - migrated from COBOL copybook CSUSR01Y
/// </summary>
[Table("Users")]
public class User
{
    [Key]
    [MaxLength(8)]
    [Column("UserId")]
    public string UserId { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    [Column("FirstName")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    [Column("LastName")]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [MaxLength(8)]
    [Column("Password")]
    public string Password { get; set; } = string.Empty;

    [Required]
    [Column("UserType")]
    public UserType UserType { get; set; }
}

/// <summary>
/// User type enumeration
/// </summary>
public enum UserType
{
    Regular = 'R',
    Admin = 'A'
}
