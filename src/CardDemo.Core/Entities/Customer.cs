using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardDemo.Core.Entities;

/// <summary>
/// Customer entity - migrated from COBOL copybook CVCUS01Y
/// </summary>
[Table("Customers")]
public class Customer
{
    [Key]
    [Column("CustomerId")]
    public int CustomerId { get; set; }

    [Required]
    [MaxLength(25)]
    [Column("FirstName")]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(25)]
    [Column("MiddleName")]
    public string? MiddleName { get; set; }

    [Required]
    [MaxLength(25)]
    [Column("LastName")]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(50)]
    [Column("AddressLine1")]
    public string AddressLine1 { get; set; } = string.Empty;

    [MaxLength(50)]
    [Column("AddressLine2")]
    public string? AddressLine2 { get; set; }

    [MaxLength(50)]
    [Column("AddressLine3")]
    public string? AddressLine3 { get; set; }

    [MaxLength(2)]
    [Column("StateCode")]
    public string? StateCode { get; set; }

    [MaxLength(3)]
    [Column("CountryCode")]
    public string? CountryCode { get; set; }

    [MaxLength(10)]
    [Column("ZipCode")]
    public string? ZipCode { get; set; }

    [MaxLength(15)]
    [Column("PhoneNumber1")]
    public string? PhoneNumber1 { get; set; }

    [MaxLength(15)]
    [Column("PhoneNumber2")]
    public string? PhoneNumber2 { get; set; }

    [Column("SSN")]
    public long SSN { get; set; }

    [MaxLength(20)]
    [Column("GovernmentIssuedId")]
    public string? GovernmentIssuedId { get; set; }

    [Column("DateOfBirth")]
    public DateTime DateOfBirth { get; set; }

    [MaxLength(10)]
    [Column("EFTAccountId")]
    public string? EFTAccountId { get; set; }

    [Column("PrimaryCardHolderIndicator")]
    public bool PrimaryCardHolderIndicator { get; set; }

    [Column("FicoCreditScore")]
    public short FicoCreditScore { get; set; }

    // Navigation properties
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
