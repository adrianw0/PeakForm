using Auth.Application.Requests.Login;
using Auth.Application.Requests.Signup;
using Auth.Application.Services;
using Auth.Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth_Api.Controllers;

[Authorize]
[ApiController]
[Route("[Controller]")]
public class AuthController(IConfiguration configuration, IUserService userService) : ControllerBase
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IUserService _userService = userService;

    [AllowAnonymous]
    [HttpPost(nameof(CreateUser))]
    public async Task<IActionResult> CreateUser([FromBody] RegisterUser registerUser)
    {
        var result = await _userService.RegisterUserAsync(registerUser);

        if (result.Success) return Ok($"Created {registerUser.UserName}");
        if (result.ErrorMessage.Equals(ErrorCodes.UserAlreadyExists)) return Conflict();

        return BadRequest(result.ErrorMessage);
    }

    [AllowAnonymous]
    [HttpPost(nameof(Login))]
    public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
    {
        var result = await _userService.LoginAsync(loginUser);

        if (result.Success) return Ok(result.Value);
        if (result.ErrorMessage.Equals(ErrorCodes.InvalidCredentials)) return Unauthorized(result.ErrorMessage);

        return BadRequest(result.ErrorMessage);
    }
}