using BarBank.Core.Account.Services;
using BarBank.Core.Auth.Dto;
using BarBank.Core.Auth.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarBank.Core.Account.Transport;

[Route("/api/accounts")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IBankAccountService _bankAccountService;
    private readonly IJwtService _jwtService;

    public AccountController(IBankAccountService bankAccountService, IJwtService jwtService)
    {
        _bankAccountService = bankAccountService;
        _jwtService = jwtService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromHeader(Name = "Authorization")] string authHeader)
    {
        var jwt = authHeader.Split(' ')[1];
        var userId = _jwtService.GetSubFromJwt(jwt);
        var account = await _bankAccountService.CreateAsync(userId);

        return Created("/api/accounts", account);
    }
}
