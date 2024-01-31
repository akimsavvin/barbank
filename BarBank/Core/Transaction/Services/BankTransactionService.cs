using BarBank.Core.Transaction.Models;
using BarBank.Core.Transaction.Storage;

namespace BarBank.Core.Transaction.Services;

public class BankTransactionService : IBankTransactionService
{
    private readonly IBankTransactionRepository _bankTransactionRepository;

    public BankTransactionService(IBankTransactionRepository bankTransactionRepository)
    {
        _bankTransactionRepository = bankTransactionRepository;
    }

    public Task<IEnumerable<BankTransaction>> GetAllByUserIdAsync(Guid userId)
    {        
        return _bankTransactionRepository.GetAllByUserIdAsync(userId);
    }
}