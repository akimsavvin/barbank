using BarBank.Common.Data;
using BarBank.Core.Transaction.Models;
using Dapper;

namespace BarBank.Core.Transaction.Storage;

public class BankTransactionPostgresRepository : IBankTransactionRepository
{
    private readonly DataContext _dataContext;

    public BankTransactionPostgresRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task InsertAndApplyAsync(BankTransaction transaction)
    {
        using (var connection = _dataContext.CreateConnection())
        {
            using (var tx = connection.BeginTransaction())
            {
                if (transaction.From != null)
                {
                    const string query = "UPDATE accounts SET balance = balance - @Amount WHERE id = @Id";
                    await connection.ExecuteAsync(
                        query,
                        new { Id = transaction.From.Id, Amount = transaction.Amount },
                        tx
                    );
                }

                if (transaction.To != null)
                {
                    const string query = "UPDATE accounts SET balance = balance + @Amount WHERE id = @Id";
                    await connection.ExecuteAsync(
                        query,
                        new { Id = transaction.To.Id, Amount = transaction.Amount },
                        tx
                    );
                }

                await connection.ExecuteAsync(
                    "INSERT INTO transactions (id, created_at, amount, account_id_from, account_id_to) VALUES (@Id, @CreatedAt, @Amount, @AccountIdFrom, @AccountIdTo)",
                    new
                    {
                        Id = transaction.Id,
                        CreatedAt = transaction.CreatedAt,
                        Amount = transaction.Amount,
                        AccountIdFrom = transaction.From?.Id,
                        AccountIdTo = transaction.To?.Id
                    },
                    tx
                );

                tx.Commit();
            }
        }
    }
    public Task<IEnumerable<BankTransaction>> GetAllByUserIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}
