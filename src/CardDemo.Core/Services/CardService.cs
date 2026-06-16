using CardDemo.Core.Entities;
using CardDemo.Core.Interfaces;

namespace CardDemo.Core.Services;

/// <summary>
/// Service implementation for card operations
/// Migrated from COBOL programs COCRDUPC, COCRDLIC, COCRDSLC
/// </summary>
public class CardService : ICardService
{
    private readonly ICardRepository _cardRepository;

    public CardService(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    public async Task<Card?> GetCardByCardNumberAsync(string cardNumber)
    {
        return await _cardRepository.GetByCardNumberAsync(cardNumber);
    }

    public async Task<IEnumerable<Card>> GetCardsByAccountIdAsync(long accountId)
    {
        return await _cardRepository.GetByAccountIdAsync(accountId);
    }

    public async Task<Card> AddCardAsync(Card card)
    {
        return await _cardRepository.AddAsync(card);
    }

    public async Task<Card> UpdateCardAsync(Card card)
    {
        return await _cardRepository.UpdateAsync(card);
    }

    public async Task DeleteCardAsync(string cardNumber)
    {
        await _cardRepository.DeleteAsync(cardNumber);
    }
}
