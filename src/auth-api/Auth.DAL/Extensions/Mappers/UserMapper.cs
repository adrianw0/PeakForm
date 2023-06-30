using Auth.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
