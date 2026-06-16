using CardDemo.Core.Entities;

namespace CardDemo.Core.Interfaces;

/// <summary>
/// Repository interface for Transaction operations
/// </summary>
public interface ITransactionRepository
{
    Task<Transaction?> GetByIdAsync(long transactionId);
    Task<IEnumerable<Transaction>> GetByAccountIdAsync(long accountId);
    Task<IEnumerable<Transaction>> GetByCardNumberAsync(string cardNumber);
    Task<Transaction> AddAsync(Transaction transaction);
    Task<Transaction> UpdateAsync(Transaction transaction);
    Task DeleteAsync(long transactionId);
}
