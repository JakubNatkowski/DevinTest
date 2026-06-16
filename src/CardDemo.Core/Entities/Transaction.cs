using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardDemo.Core.Entities;

/// <summary>
/// Transaction entity - migrated from COBOL copybook CVTRA05Y
/// </summary>
[Table("Transactions")]
public class Transaction
{
    [Key]
    [Column("TransactionId")]
    public long TransactionId { get; set; }

    [Required]
    [Column("AccountId")]
    public long AccountId { get; set; }

    [Required]
    [MaxLength(16)]
    [Column("CardNumber")]
    public string CardNumber { get; set; } = string.Empty;

    [Required]
    [Column("TransactionDate")]
    public DateTime TransactionDate { get; set; }

    [Required]
    [MaxLength(2)]
    [Column("TransactionType")]
    public string TransactionType { get; set; } = string.Empty;

    [Required]
    [MaxLength(4)]
    [Column("TransactionCategory")]
    public string TransactionCategory { get; set; } = string.Empty;

    [Column("TransactionAmount")]
    public decimal TransactionAmount { get; set; }

    [MaxLength(50)]
    [Column("MerchantName")]
    public string? MerchantName { get; set; }

    [MaxLength(50)]
    [Column("MerchantCity")]
    public string? MerchantCity { get; set; }

    [MaxLength(2)]
    [Column("MerchantState")]
    public string? MerchantState { get; set; }

    [Column("PostedIndicator")]
    public bool PostedIndicator { get; set; }

    [Column("PostingDate")]
    public DateTime? PostingDate { get; set; }

    // Foreign key to Account
    [ForeignKey("AccountId")]
    public virtual Account? Account { get; set; }
}
