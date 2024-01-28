using BarBank.Core.User.Models;

namespace BarBank.Core.User.Storage;

public interface IBankUserRepository
{
    public Task InsertAsync(BankUser bankUser);
    public Task<BankUser> GetOneByIdAsync(Guid id);
}
