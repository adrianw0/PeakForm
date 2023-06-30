using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Auth.Infrastructure.Models.DTOs;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Auth.Infrastructure.Services.Jwt;
public class JwtService : IAuthTokenService
{
    private readonly IOptions<JwtSettings> _settings;

    public JwtService(IOptions<JwtSettings> settings)
    {
        _settings = settings;
    }

    public JwtSecurityToken GenerateToken(AuthUserDto userDto)
    {

        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userDto.UserId),
            new Claim(ClaimTypes.Email, userDto.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Value.Key));

        var token = new JwtSecurityToken(
            issuer: _settings.Value.Issuer,
            audience: _settings.Value.Audience,
            expires: DateTime.Now.AddHours(2),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));;

        return token;
    }
}
