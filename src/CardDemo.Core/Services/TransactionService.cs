using CardDemo.Core.Entities;
using CardDemo.Core.Interfaces;

namespace CardDemo.Core.Services;

/// <summary>
/// Service implementation for transaction operations
/// Migrated from COBOL programs COTRN00C, COTRN01C, COTRN02C
/// </summary>
public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<Transaction?> GetTransactionByIdAsync(long transactionId)
    {
        return await _transactionRepository.GetByIdAsync(transactionId);
    }

    public async Task<IEnumerable<Transaction>> GetTransactionsByAccountIdAsync(long accountId)
    {
        return await _transactionRepository.GetByAccountIdAsync(accountId);
    }

    public async Task<IEnumerable<Transaction>> GetTransactionsByCardNumberAsync(string cardNumber)
    {
        return await _transactionRepository.GetByCardNumberAsync(cardNumber);
    }

    public async Task<Transaction> AddTransactionAsync(Transaction transaction)
    {
        return await _transactionRepository.AddAsync(transaction);
    }

    public async Task<Transaction> UpdateTransactionAsync(Transaction transaction)
    {
        return await _transactionRepository.UpdateAsync(transaction);
    }

    public async Task DeleteTransactionAsync(long transactionId)
    {
        await _transactionRepository.DeleteAsync(transactionId);
    }
}
