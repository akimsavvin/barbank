using BarBank.Core.Auth.Dto;

namespace BarBank.Core.Auth.Services;

public interface IAuthService
{
    public Task<AuthDto> SignUpAsync(SignUpDto signUpDto);
}
