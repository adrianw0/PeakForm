namespace PeakForm.Api.Settings;

public class RateLimitSettings
{
    public const string RateLimit = "RateLimitSettings";

    public int PermitLimit { get; set; } = 4;
    public int Window { get; set; } = 12;
    public int QueueLimit { get; set; } = 2;
}
