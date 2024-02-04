using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace BarBank.Core.Auth.Services;

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;

    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Create(string sub)
    {
        var jwtSecret = _configuration.GetValue<string>("Jwt:Secret")!;
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, sub)
        };

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(7),
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}