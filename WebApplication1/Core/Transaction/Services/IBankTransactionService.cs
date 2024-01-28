using BarBank.Core.Transaction.Models;

namespace BarBank.Core.Transaction.Services;

public interface IBankTransactionService
{
    public Task<IEnumerable<BankTransaction>> GetAllByUserIdAsync(Guid userId);
}
