using CardDemo.Core.Entities;
using CardDemo.Core.Interfaces;
using CardDemo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CardDemo.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for Transaction operations
/// </summary>
public class TransactionRepository : ITransactionRepository
{
    private readonly CardDemoDbContext _context;

    public TransactionRepository(CardDemoDbContext context)
    {
        _context = context;
    }

    public async Task<Transaction?> GetByIdAsync(long transactionId)
    {
        return await _context.Transactions
            .Include(t => t.Account)
            .FirstOrDefaultAsync(t => t.TransactionId == transactionId);
    }

    public async Task<IEnumerable<Transaction>> GetByAccountIdAsync(long accountId)
    {
        return await _context.Transactions
            .Where(t => t.AccountId == accountId)
            .OrderByDescending(t => t.TransactionDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Transaction>> GetByCardNumberAsync(string cardNumber)
    {
        return await _context.Transactions
            .Where(t => t.CardNumber == cardNumber)
            .OrderByDescending(t => t.TransactionDate)
            .ToListAsync();
    }

    public async Task<Transaction> AddAsync(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();
        return transaction;
    }

    public async Task<Transaction> UpdateAsync(Transaction transaction)
    {
        _context.Transactions.Update(transaction);
        await _context.SaveChangesAsync();
        return transaction;
    }

    public async Task DeleteAsync(long transactionId)
    {
        var transaction = await GetByIdAsync(transactionId);
        if (transaction != null)
        {
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
