using CardDemo.Core.Entities;

namespace CardDemo.Core.Interfaces;

/// <summary>
/// Repository interface for Account operations
/// </summary>
public interface IAccountRepository
{
    Task<Account?> GetByIdAsync(long accountId);
    Task<IEnumerable<Account>> GetByCustomerIdAsync(int customerId);
    Task<Account> AddAsync(Account account);
    Task<Account> UpdateAsync(Account account);
    Task DeleteAsync(long accountId);
}
