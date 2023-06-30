using Auth.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Auth.DAL.Extensions.Mappers;
using System.Reflection.Metadata.Ecma335;
using Auth.Domain.Common.Result;
using Auth.Domain.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.Contracts;
using Auth.DAL.Exceptions;

namespace Auth.DAL.Repository;
public class UserRepository : IUserRepository
{
    private readonly UserManager<IdentityUser> _userManager;
    public UserRepository(UserManager<IdentityUser> userManager )
    {
        _userManager = userManager;
    }

    public async Task<Result<User>> FindByEmailAsync(string Email)
    {
        var identityUser = await _userManager.FindByEmailAsync(Email);

        if (identityUser is null) return Result.Fail<User>(ErrorCodes.UserNotFound);

        return Result.Ok(identityUser.MapToUser());
    }

    public async Task<Result<User>> AuthenticateUser(string email, string password)
    {
        var identityUser = await _userManager.FindByEmailAsync(email);
        if (identityUser is null) return Result.Fail<User>(ErrorCodes.InvalidCredentials);

        var success = await _userManager.CheckPasswordAsync(identityUser, password);
        if (!success) return Result.Fail<User>(ErrorCodes.InvalidCredentials);

        return Result.Ok(identityUser.MapToUser());
    }

    public async Task<Result<User>> CreateUserAsync(User user, string password)
    {
        IdentityUser identity = new()
        {
            UserName = user.UserName,
            Email = user.Email,
            SecurityStamp = user.UserName
        };

        var result = await _userManager.CreateAsync(identity, password);
        if(result.Succeeded) return Result.Ok(user);

        if(result.Errors.Any(x=>x.Code.Contains("Duplicate"))) return Result.Fail<User>(ErrorCodes.UserAlreadyExists);


        var errorCodes = string.Join(';', result.Errors.Select(x => x.Code).ToList());

        throw new UserCreationException(errorCodes);
        
    }
}
