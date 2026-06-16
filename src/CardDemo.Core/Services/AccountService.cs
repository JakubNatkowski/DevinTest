using CardDemo.Core.Entities;
using CardDemo.Core.Interfaces;

namespace CardDemo.Core.Services;

/// <summary>
/// Service implementation for account operations
/// Migrated from COBOL programs COACTUPC, COACTVWC
/// </summary>
public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ICardRepository _cardRepository;
    private readonly ICardAccountCrossReferenceService _xrefService;

    public AccountService(
        IAccountRepository accountRepository,
        ICardRepository cardRepository,
        ICardAccountCrossReferenceService xrefService)
    {
        _accountRepository = accountRepository;
        _cardRepository = cardRepository;
        _xrefService = xrefService;
    }

    public async Task<Account?> GetAccountByIdAsync(long accountId)
    {
        return await _accountRepository.GetByIdAsync(accountId);
    }

    public async Task<IEnumerable<Account>> GetAccountsByCustomerIdAsync(int customerId)
    {
        return await _accountRepository.GetByCustomerIdAsync(customerId);
    }

    public async Task<Account> UpdateAccountAsync(Account account)
    {
        return await _accountRepository.UpdateAsync(account);
    }

    public async Task<Account?> GetAccountByCardNumberAsync(string cardNumber)
    {
        var xref = await _xrefService.GetByCardNumberAsync(cardNumber);
        if (xref == null)
        {
            return null;
        }

        return await _accountRepository.GetByIdAsync(xref.AccountId);
    }
}
