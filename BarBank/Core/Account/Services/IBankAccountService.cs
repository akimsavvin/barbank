using BarBank.Core.Account.Exceptions;
using BarBank.Core.Account.Models;
using BarBank.Core.Transaction.Models;

namespace BarBank.Core.Account.Services;

public interface IBankAccountService
{
    public Task<BankAccount> CreateAsync(Guid userId);
    public Task<BankTransaction> WithdrawAsync(Guid userId, Guid accountId, int amount);
    public Task<BankTransaction> ReplenishAsync(Guid userId, Guid accountId, int amount);
    public Task<BankTransaction> TransferAsync(Guid userId, Guid fromId, Guid toId, int amount);
}