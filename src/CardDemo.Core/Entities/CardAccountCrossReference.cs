using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardDemo.Core.Entities;

/// <summary>
/// Card Account Cross Reference entity - migrated from COBOL copybook CVACT03Y
/// </summary>
[Table("CardAccountCrossReferences")]
public class CardAccountCrossReference
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(16)]
    [Column("CardNumber")]
    public string CardNumber { get; set; } = string.Empty;

    [Required]
    [Column("CustomerId")]
    public int CustomerId { get; set; }

    [Required]
    [Column("AccountId")]
    public long AccountId { get; set; }
}
