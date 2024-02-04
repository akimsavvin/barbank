using BarBank.Core.User.Dto;
using BarBank.Core.Auth.Dto;
using BarBank.Core.User.Services;
using BarBank.Core.Auth.Exceptions;

namespace BarBank.Core.Auth.Services;

public class AuthService : IAuthService
{
    private readonly IBankUserService _bankUserService;
    private readonly IJwtService _jwtService;

    public AuthService(IBankUserService bankUserService, IJwtService jwtService)
    {
        _bankUserService = bankUserService;
        _jwtService = jwtService;
    }

    // Авторизация
    public async Task<AuthDto> SignInAsync(SignInDto signInDto)
    {
        var user = await _bankUserService.GetOneByPhoneAsync(signInDto.Phone);

        if (signInDto.Password != user.Password)
        {
            throw new InvalidPasswordException();
        }

        var accessToken = _jwtService.Create(user.Id.ToString());

        return new AuthDto(accessToken);
    }

    // Регистрация
    public async Task<AuthDto> SignUpAsync(SignUpDto signUpDto)
    {
        if (signUpDto.Password != signUpDto.PasswordConfirm)
        {
            throw new PasswordsMismatchException();
        }

        var createBankUserDto = new CreateBankUserDto(
            signUpDto.FirstName,
            signUpDto.LastName,
            signUpDto.MiddleName,
            signUpDto.Phone,
            signUpDto.Password);
 
        var user = await _bankUserService.CreateAsync(createBankUserDto);
        var accessToken = _jwtService.Create(user.Id.ToString());

        return new AuthDto(accessToken);
    }
}