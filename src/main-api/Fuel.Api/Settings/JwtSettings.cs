﻿namespace Fuel.Api.Settings;

public class JwtSettings
{
    public const string Jwt = "JwtSettings" ;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
}
