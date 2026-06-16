using CardDemo.Core.Entities;

namespace CardDemo.Core.Interfaces;

/// <summary>
/// Repository interface for Card operations
/// </summary>
public interface ICardRepository
{
    Task<Card?> GetByCardNumberAsync(string cardNumber);
    Task<IEnumerable<Card>> GetByAccountIdAsync(long accountId);
    Task<Card> AddAsync(Card card);
    Task<Card> UpdateAsync(Card card);
    Task DeleteAsync(string cardNumber);
}
