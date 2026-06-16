using CardDemo.Core.Entities;

namespace CardDemo.Core.Services;

/// <summary>
/// Service interface for account operations
/// Migrated from COBOL programs COACTUPC, COACTVWC
/// </summary>
public interface IAccountService
{
    Task<Account?> GetAccountByIdAsync(long accountId);
    Task<IEnumerable<Account>> GetAccountsByCustomerIdAsync(int customerId);
    Task<Account> UpdateAccountAsync(Account account);
    Task<Account?> GetAccountByCardNumberAsync(string cardNumber);
}
