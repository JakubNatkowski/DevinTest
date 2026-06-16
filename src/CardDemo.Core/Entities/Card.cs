using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardDemo.Core.Entities;

/// <summary>
/// Card entity - migrated from COBOL copybook CVACT02Y
/// </summary>
[Table("Cards")]
public class Card
{
    [Key]
    [MaxLength(16)]
    [Column("CardNumber")]
    public string CardNumber { get; set; } = string.Empty;

    [Required]
    [Column("AccountId")]
    public long AccountId { get; set; }

    [Column("CVVCode")]
    public short CVVCode { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("EmbossedName")]
    public string EmbossedName { get; set; } = string.Empty;

    [Column("ExpirationDate")]
    public DateTime ExpirationDate { get; set; }

    [Required]
    [Column("ActiveStatus")]
    public bool ActiveStatus { get; set; }

    // Foreign key to Account
    [ForeignKey("AccountId")]
    public virtual Account? Account { get; set; }
}
