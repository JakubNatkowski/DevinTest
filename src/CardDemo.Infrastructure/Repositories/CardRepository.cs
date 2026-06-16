using CardDemo.Core.Entities;
using CardDemo.Core.Interfaces;
using CardDemo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CardDemo.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for Card operations
/// </summary>
public class CardRepository : ICardRepository
{
    private readonly CardDemoDbContext _context;

    public CardRepository(CardDemoDbContext context)
    {
        _context = context;
    }

    public async Task<Card?> GetByCardNumberAsync(string cardNumber)
    {
        return await _context.Cards
            .Include(c => c.Account)
            .FirstOrDefaultAsync(c => c.CardNumber == cardNumber);
    }

    public async Task<IEnumerable<Card>> GetByAccountIdAsync(long accountId)
    {
        return await _context.Cards
            .Where(c => c.AccountId == accountId)
            .ToListAsync();
    }

    public async Task<Card> AddAsync(Card card)
    {
        _context.Cards.Add(card);
        await _context.SaveChangesAsync();
        return card;
    }

    public async Task<Card> UpdateAsync(Card card)
    {
        _context.Cards.Update(card);
        await _context.SaveChangesAsync();
        return card;
    }

    public async Task DeleteAsync(string cardNumber)
    {
        var card = await GetByCardNumberAsync(cardNumber);
        if (card != null)
        {
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
        }
    }
}
