namespace BarBank.Core.Auth.Services;

public interface IJwtService
{
    public Task<string> CreateAsync(string sub);
}
