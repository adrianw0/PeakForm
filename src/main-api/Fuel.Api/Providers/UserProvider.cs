using Core.Interfaces.Providers;
using Fuel.Api.Extensions;

namespace Fuel.Api.Providers;

public class UserProvider : IUserProvider
{
    private readonly IHttpContextAccessor _accessor;
    public UserProvider(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public string UserId => GetUserId();

    private string GetUserId()
    {
        return _accessor.HttpContext is null ? Guid.Empty.ToString() : _accessor.HttpContext.User.GetUserId().ToString();
    }
}
