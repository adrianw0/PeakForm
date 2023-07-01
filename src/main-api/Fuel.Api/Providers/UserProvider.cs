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

    public Guid GetUserId()
    {
        
        if (_accessor.HttpContext is null) return Guid.Empty;
        return _accessor.HttpContext.User.GetUserId() ;
    }
}
