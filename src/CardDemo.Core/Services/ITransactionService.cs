using CardDemo.Core.Entities;

namespace CardDemo.Core.Services;

/// <summary>
/// Service interface for transaction operations
/// Migrated from COBOL programs COTRN00C, COTRN01C, COTRN02C
/// </summary>
public interface ITransactionService
{
    Task<Transaction?> GetTransactionByIdAsync(long transactionId);
    Task<IEnumerable<Transaction>> GetTransactionsByAccountIdAsync(long accountId);
    Task<IEnumerable<Transaction>> GetTransactionsByCardNumberAsync(string cardNumber);
    Task<Transaction> AddTransactionAsync(Transaction transaction);
    Task<Transaction> UpdateTransactionAsync(Transaction transaction);
    Task DeleteTransactionAsync(long transactionId);
}
