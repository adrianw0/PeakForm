using System.Security.Claims;

namespace Fuel.Api.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal principal)
    {
        if (!principal.Claims.Any()) return Guid.Empty;
        return Guid.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
