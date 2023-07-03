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

    public string UserId { get=> GetUserId(); }
    private string GetUserId()
    {
        
        if (_accessor.HttpContext is null) return Guid.Empty.ToString();

        return _accessor.HttpContext.User.GetUserId().ToString() ;
    }
}
