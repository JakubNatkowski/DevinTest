using CardDemo.Core.Entities;

namespace CardDemo.Core.Interfaces;

/// <summary>
/// Service interface for Card Account Cross Reference operations
/// </summary>
public interface ICardAccountCrossReferenceService
{
    Task<CardAccountCrossReference?> GetByCardNumberAsync(string cardNumber);
    Task<IEnumerable<CardAccountCrossReference>> GetByAccountIdAsync(long accountId);
    Task<CardAccountCrossReference> AddAsync(CardAccountCrossReference xref);
}
