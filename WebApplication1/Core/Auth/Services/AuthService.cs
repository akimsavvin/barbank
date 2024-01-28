using BarBank.Core.Auth.Dto;
using BarBank.Core.User.Dto;
using BarBank.Core.User.Services;

namespace BarBank.Core.Auth.Services;

public class AuthService: IAuthService
{
    private readonly IBankUserService _bankUserService;
    private readonly IJwtService _jwtService;

    public AuthService(IBankUserService bankUserService, IJwtService jwtService)
    {
        _bankUserService = bankUserService;
        _jwtService = jwtService;
    }

    // Регистрация
    public async Task<AuthDto> SignUpAsync(SignUpDto signUpDto)
    {
        var createBankUserDto = new CreateBankUserDto(
            signUpDto.FirstName, 
            signUpDto.LastName, 
            signUpDto.MiddleName, 
            signUpDto.Phone, 
            signUpDto.Password);
        var user = await _bankUserService.CreateAsync(createBankUserDto);
        var accessToken = await _jwtService.CreateAsync(user.Id.ToString());
        return new AuthDto(accessToken);
    }
}
