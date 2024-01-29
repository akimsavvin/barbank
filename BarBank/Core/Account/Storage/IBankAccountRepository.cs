using BarBank.Core.Account.Models;

namespace BarBank.Core.Account.Storage;

public interface IBankAccountRepository
{
    public Task Insert(Guid userId, BankAccount bankAccount);
    public Task<BankAccount> GetOneById(Guid id);
    public Task<BankAccount> GetOneByIdAndUserId(Guid id, Guid userId);
}
