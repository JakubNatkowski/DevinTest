using CardDemo.Core.Entities;
using CardDemo.Core.Interfaces;
using CardDemo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CardDemo.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for Account operations
/// </summary>
public class AccountRepository : IAccountRepository
{
    private readonly CardDemoDbContext _context;

    public AccountRepository(CardDemoDbContext context)
    {
        _context = context;
    }

    public async Task<Account?> GetByIdAsync(long accountId)
    {
        return await _context.Accounts
            .Include(a => a.Customer)
            .Include(a => a.Cards)
            .FirstOrDefaultAsync(a => a.AccountId == accountId);
    }

    public async Task<IEnumerable<Account>> GetByCustomerIdAsync(int customerId)
    {
        return await _context.Accounts
            .Include(a => a.Cards)
            .Where(a => a.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task<Account> AddAsync(Account account)
    {
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();
        return account;
    }

    public async Task<Account> UpdateAsync(Account account)
    {
        _context.Accounts.Update(account);
        await _context.SaveChangesAsync();
        return account;
    }

    public async Task DeleteAsync(long accountId)
    {
        var account = await GetByIdAsync(accountId);
        if (account != null)
        {
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
        }
    }
}
