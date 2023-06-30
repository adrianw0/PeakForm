using Auth.Application.Requests.Login;
using Auth.Application.Requests.Signup;
using Auth.Application.Services;
using Auth.Domain.Common;
using Auth.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth_Api.Controllers;

[Authorize]
[ApiController]
[Route("AuthController")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;
    public AuthController( IConfiguration configuration, IUserService userService)
    {
        _configuration = configuration;
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser([FromBody] RegisterUser registerUser)
    {
        var result = await _userService.RegisterUserAsync(registerUser);

        if (result.Success) return Ok($"Created {registerUser.UserName}" );
        if (result.ErrorMessage.Equals(ErrorCodes.UserAlreadyExists)) return Conflict();
        
        return BadRequest(result.ErrorMessage);
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
    {
        var result = await _userService.LoginAsync(loginUser);

        if (result.Success) return Ok(result.Value);
        if(result.ErrorMessage.Equals(ErrorCodes.InvalidCredentials)) return Unauthorized(result.ErrorMessage);

        return BadRequest(result.ErrorMessage);
    }
}
