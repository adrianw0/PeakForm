using Auth.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Auth.DAL.Extensions.Mappers;

public static class UserMapper
{
    public static User MapToUser(this IdentityUser identityUser)
    {
        return new User()
        {
            Id = identityUser.Id,
            Email = identityUser.Email,
            UserName = identityUser.UserName
        };
    }
}