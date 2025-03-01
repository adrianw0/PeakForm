﻿using Auth.DAL.Exceptions;
using Auth.DAL.Extensions.Mappers;
using Auth.Domain.Common;
using Auth.Domain.Common.Result;
using Auth.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Auth.DAL.Repository;

public class UserRepository(UserManager<IdentityUser> userManager) : IUserRepository
{
    private readonly UserManager<IdentityUser> _userManager = userManager;

    public async Task<Result<User>> FindByEmailAsync(string email)
    {
        var identityUser = await _userManager.FindByEmailAsync(email);

        return identityUser is null ? Result.Fail<User>(ErrorCodes.UserNotFound) : Result.Ok(identityUser.MapToUser());
    }

    public async Task<Result<User>> AuthenticateUser(string email, string password)
    {
        var identityUser = await _userManager.FindByEmailAsync(email);
        if (identityUser is null) return Result.Fail<User>(ErrorCodes.InvalidCredentials);

        var success = await _userManager.CheckPasswordAsync(identityUser, password);
        return !success ? Result.Fail<User>(ErrorCodes.InvalidCredentials) : Result.Ok(identityUser.MapToUser());
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
        if (result.Succeeded) return Result.Ok(user);

        if (result.Errors.Any(x => x.Code.Contains("Duplicate"))) return Result.Fail<User>(ErrorCodes.UserAlreadyExists);

        var errorCodes = string.Join(';', result.Errors.Select(x => x.Code).ToList());

        throw new UserCreationException(errorCodes);
    }
}