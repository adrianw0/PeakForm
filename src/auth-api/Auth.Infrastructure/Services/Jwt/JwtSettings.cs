namespace Auth.Infrastructure.Services.Jwt;

public class JwtSettings
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public long LifeTimeInSeconds { get; set; } = 7200;
    public string Key { get; set; }
}