using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardDemo.Core.Entities;

/// <summary>
/// Account entity - migrated from COBOL copybook CVACT01Y
/// </summary>
[Table("Accounts")]
public class Account
{
    [Key]
    [Column("AccountId")]
    public long AccountId { get; set; }

    [Required]
    [Column("ActiveStatus")]
    public bool ActiveStatus { get; set; }

    [Column("CurrentBalance")]
    public decimal CurrentBalance { get; set; }

    [Column("CreditLimit")]
    public decimal CreditLimit { get; set; }

    [Column("CashCreditLimit")]
    public decimal CashCreditLimit { get; set; }

    [Column("OpenDate")]
    public DateTime OpenDate { get; set; }

    [Column("ExpirationDate")]
    public DateTime ExpirationDate { get; set; }

    [Column("ReissueDate")]
    public DateTime? ReissueDate { get; set; }

    [Column("CurrentCycleCredit")]
    public decimal CurrentCycleCredit { get; set; }

    [Column("CurrentCycleDebit")]
    public decimal CurrentCycleDebit { get; set; }

    [MaxLength(10)]
    [Column("AddressZip")]
    public string? AddressZip { get; set; }

    [MaxLength(10)]
    [Column("GroupId")]
    public string? GroupId { get; set; }

    // Foreign key to Customer
    [Column("CustomerId")]
    public int CustomerId { get; set; }

    // Navigation properties
    [ForeignKey("CustomerId")]
    public virtual Customer? Customer { get; set; }
    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
