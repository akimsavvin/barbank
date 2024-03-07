using BarBank.Core.Auth.Dto;
using BarBank.Core.Auth.Exceptions;
using BarBank.Core.Auth.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BarBank.Core.Auth.Transport;

[Route("/api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public async Task<IActionResult> SignInAsync([FromBody] SignInDto signInDto)
    {
        try
        {
            var authDto = await _authService.SignInAsync(signInDto);
            return Ok(authDto);
        }
        catch (InvalidPasswordException exception) 
        {
            return BadRequest(exception);
        }
        catch (Exception exception)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, exception);
        }
    }

    [HttpPut]
    public async Task<IActionResult> SignUpAsync([FromBody] SignUpDto signUpDto)
    {
        try
        {
            var authDto = await _authService.SignUpAsync(signUpDto);
            return Ok(authDto);
        }
        catch (PasswordsMismatchException exception)
        {
            return BadRequest(exception);
        }
    }
}