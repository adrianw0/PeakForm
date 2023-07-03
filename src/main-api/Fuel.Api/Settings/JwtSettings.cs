namespace Fuel.Api.Settings;

public class JwtSettings
{
    public const string Jwt = "JwtSettings" ;
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public string Key { get; set; } = null!;
}
