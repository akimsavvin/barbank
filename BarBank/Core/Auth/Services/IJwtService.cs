namespace BarBank.Core.Auth.Services;

public interface IJwtService
{
    public string Create(string sub);
    public Guid GetSubFromJwt(string jwt);
}
