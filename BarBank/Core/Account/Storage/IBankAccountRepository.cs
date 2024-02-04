using BarBank.Core.Account.Models;

namespace BarBank.Core.Account.Storage;

public interface IBankAccountRepository
{
    public Task InsertAsync(Guid userId, BankAccount bankAccount);
    public Task<BankAccount> GetOneByIdAsync(Guid id);
    public Task<BankAccount> GetOneByIdAndUserIdAsync(Guid id, Guid userId);
}