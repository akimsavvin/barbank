using BarBank.Common.Data;
using BarBank.Core.User.Exeptions;
using BarBank.Core.User.Models;
using Dapper;

namespace BarBank.Core.User.Storage;

public class BankUserPostgresRepository : IBankUserRepository
{
    private readonly DataContext _dataContext;

    public BankUserPostgresRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<BankUser> GetOneByIdAsync(Guid id)
    {
        using (var connection = _dataContext.CreateConnection())
        {
            const string query = "SELECT id, first_name, last_name, middle_name, phone, password FROM users WHERE id = @Id";
            var bankUser = await connection.QueryFirstOrDefaultAsync<BankUser>(query, new { Id = id });
            if (bankUser == null)
            {
                throw new BankUserNotFoundExeption();
            }
            return bankUser;
        }
    }

    public async Task<BankUser> GetOneByPhoneAsync(string phone)
    {
        using (var connection = _dataContext.CreateConnection())
        {
            const string query = "SELECT id, first_name, last_name, middle_name, phone, password FROM users WHERE phone = @Phone";
            var bankUser = await connection.QueryFirstOrDefaultAsync<BankUser>(query, new { Phone = phone });
            if (bankUser == null)
            {
                throw new BankUserNotFoundExeption();
            }
            return bankUser;
        }
    }

    public async Task InsertAsync(BankUser bankUser)
    {
        using (var connection = _dataContext.CreateConnection())
        {
            const string query = "INSERT INTO users (id, first_name, last_name, middle_name, phone, password) VALUES (@Id, @FirstName, @LastName, @MiddleName, @Phone, @Password)";
            await connection.ExecuteAsync(query,
                new
                {
                    Id = bankUser.Id,
                    FirstName = bankUser.FirstName,
                    LastName = bankUser.LastName,
                    MiddleName = bankUser.MiddleName,
                    Phone = bankUser.Phone,
                    Password = bankUser.Password
                }
            );
        }
    }
}
