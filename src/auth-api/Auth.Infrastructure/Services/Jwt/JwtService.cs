using Auth.Infrastructure.Models.DTOs;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.Infrastructure.Services.Jwt;

public class JwtService(IOptions<JwtSettings> settings) : IAuthTokenService
{
    private readonly IOptions<JwtSettings> _settings = settings;

    public JwtSecurityToken GenerateToken(AuthUserDto userDto)
    {
        var authClaims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, userDto.UserId),
            new(ClaimTypes.Email, userDto.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Value.Key));

        var token = new JwtSecurityToken(
            issuer: _settings.Value.Issuer,
            audience: _settings.Value.Audience,
            expires: DateTime.Now.AddHours(2),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)); ;

        return token;
    }
}