using Auth.Application.Requests.Login;
using Auth.Application.Requests.Signup;
using Auth.DAL.Repository;
using Auth.Domain.Common.Result;
using Auth.Domain.Models;
using Auth.Infrastructure.Models.DTOs;
using Auth.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;

namespace Auth.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthTokenService _authService;
    private readonly ILogger<UserService> _logger;

    public UserService(IUserRepository userRepository, IAuthTokenService authService, ILogger<UserService> logger)
    {
        _userRepository = userRepository;
        _authService = authService;
        _logger = logger;
    }

    public async Task<Result<string>> LoginAsync(LoginUser loginUser)
    {
        var result = await _userRepository.AuthenticateUser(loginUser.Email, loginUser.Password);
        if (!result.Success) return Result.Fail<string>(result.ErrorMessage);

        var userDto = new AuthUserDto
        {
            Email = loginUser.Email,
            UserId = result.Value.Id
        };

        var jwtToken = _authService.GenerateToken(userDto);

        return Result.Ok(new JwtSecurityTokenHandler().WriteToken(jwtToken));
    }

    public async Task<Result<string>> RegisterUserAsync(RegisterUser registerUser)
    {
        User user = new()
        {
            UserName = registerUser.UserName,
            Email = registerUser.Email
        };

        var creationResult = await _userRepository.CreateUserAsync(user, registerUser.Password);

        if (creationResult.Success) return Result.Ok("Ok");

        _logger.LogError(creationResult.ErrorMessage);
        return Result.Fail<string>(creationResult.ErrorMessage);

    }
}