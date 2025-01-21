using System.Security.Claims;

namespace PeakForm.Api.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal principal)
    {
        if (!principal.Claims.Any()) return Guid.Empty;

        var value = principal.FindFirstValue(ClaimTypes.NameIdentifier);
        return value == null ? Guid.Empty : Guid.Parse(value);
    }
}
