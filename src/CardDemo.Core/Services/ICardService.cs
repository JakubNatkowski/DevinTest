using CardDemo.Core.Entities;

namespace CardDemo.Core.Services;

/// <summary>
/// Service interface for card operations
/// Migrated from COBOL programs COCRDUPC, COCRDLIC, COCRDSLC
/// </summary>
public interface ICardService
{
    Task<Card?> GetCardByCardNumberAsync(string cardNumber);
    Task<IEnumerable<Card>> GetCardsByAccountIdAsync(long accountId);
    Task<Card> AddCardAsync(Card card);
    Task<Card> UpdateCardAsync(Card card);
    Task DeleteCardAsync(string cardNumber);
}
