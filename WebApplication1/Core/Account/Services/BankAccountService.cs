using BarBank.Core.Account.Models;
using BarBank.Core.Account.Storage;
using BarBank.Core.Transaction.Models;
using BarBank.Core.Transaction.Storage;

namespace BarBank.Core.Account.Services;

public class BankAccountService : IBankAccountService
{
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly IBankTransactionRepository _bankTransactionRepository;

    public BankAccountService(IBankAccountRepository bankAccountRepository, IBankTransactionRepository bankTransactionRepository)
    {
        _bankAccountRepository = bankAccountRepository;
        _bankTransactionRepository = bankTransactionRepository;
    }

    public async Task<BankAccount> CreateAsync(Guid userId)
    {
        const int DEFAULT_BALANCE = 0;
        var bankAccount = new BankAccount(Guid.NewGuid(), DEFAULT_BALANCE);
        await _bankAccountRepository.Insert(userId, bankAccount);
        return bankAccount;
    }

    public async Task<BankTransaction> WithdrawAsync(Guid userId, Guid accountId, int amount) 
    {
        var bankAccount = await _bankAccountRepository.GetOneByIdAndUserId(accountId, userId);
        var transaction = bankAccount.Withdraw(amount);
        await _bankTransactionRepository.InsertAndApplyAsync(transaction);
        return transaction;
    }

    public async Task<BankTransaction> ReplenishAsync(Guid userId, Guid accountId, int amount) 
    {
        var bankAccount = await _bankAccountRepository.GetOneByIdAndUserId(accountId, userId);
        var transaction = bankAccount.Replenish(amount);
        await _bankTransactionRepository.InsertAndApplyAsync(transaction);
        return transaction;
    }

    public async Task<BankTransaction> TransferAsync(Guid userId, Guid fromId, Guid toId, int amount) 
    {
        var fromAccount = await _bankAccountRepository.GetOneByIdAndUserId(fromId, userId);
        var toAccount = await _bankAccountRepository.GetOneById(toId);
        var transaction = fromAccount.Transfer(amount, toAccount);
        await _bankTransactionRepository.InsertAndApplyAsync(transaction);
        return transaction;
    }
}