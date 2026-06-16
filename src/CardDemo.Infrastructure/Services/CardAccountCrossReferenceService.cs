using CardDemo.Core.Entities;
using CardDemo.Core.Interfaces;
using CardDemo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CardDemo.Infrastructure.Services;

/// <summary>
/// Service implementation for Card Account Cross Reference operations
/// </summary>
public class CardAccountCrossReferenceService : ICardAccountCrossReferenceService
{
    private readonly CardDemoDbContext _context;

    public CardAccountCrossReferenceService(CardDemoDbContext context)
    {
        _context = context;
    }

    public async Task<CardAccountCrossReference?> GetByCardNumberAsync(string cardNumber)
    {
        return await _context.CardAccountCrossReferences
            .FirstOrDefaultAsync(x => x.CardNumber == cardNumber);
    }

    public async Task<IEnumerable<CardAccountCrossReference>> GetByAccountIdAsync(long accountId)
    {
        return await _context.CardAccountCrossReferences
            .Where(x => x.AccountId == accountId)
            .ToListAsync();
    }

    public async Task<CardAccountCrossReference> AddAsync(CardAccountCrossReference xref)
    {
        _context.CardAccountCrossReferences.Add(xref);
        await _context.SaveChangesAsync();
        return xref;
    }
}
