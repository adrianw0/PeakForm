using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Services.Jwt;
public class JwtSettings
{
    public required string Issuer { get; set; } 
    public required string Audience { get; set; } 
    public long LifeTimeInSeconds { get; set; } = 7200;
    public required string Key { get; set; } 
}
