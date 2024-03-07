using Npgsql;
using System.Data;

namespace BarBank.Common.Data;

public class DataContext
{
    private readonly IConfiguration _configuration;

    public DataContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        var connectionString = _configuration.GetValue<string>("Database:ConnectionString")!;
        return new NpgsqlConnection(connectionString);
    }
}