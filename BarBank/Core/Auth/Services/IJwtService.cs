namespace BarBank.Core.Auth.Services;

public interface IJwtService
{
    public string Create(string sub);
}
