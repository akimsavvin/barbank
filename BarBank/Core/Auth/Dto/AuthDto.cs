namespace BarBank.Core.Auth.Dto;

public class AuthDto
{
    public string AccessToken { get; }

    public AuthDto(string accessToken) 
    {
        AccessToken = accessToken;
    }
}
