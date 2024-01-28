using BarBank.Core.Transaction.Models;

namespace BarBank.Core.Transaction.Storage;

public interface IBankTransactionRepository
{
    public Task InsertAndApplyAsync(BankTransaction transaction);
    public Task<IEnumerable<BankTransaction>> GetAllByUserIdAsync(Guid userId);
}
