using Auth.Infrastructure.Models.DTOs;
using System.IdentityModel.Tokens.Jwt;

namespace Auth.Infrastructure.Services;
public interface IAuthTokenService
{
    public JwtSecurityToken GenerateToken(AuthUserDto userDto);
}
