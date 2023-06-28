using Auth_Api.Models.Login;
using Auth_Api.Models.Singup;
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
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _configuration;
    public AuthController(UserManager<IdentityUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    [AllowAnonymous]
    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser([FromBody] RegisterUser registerUser)
    {
        if (registerUser is null) return BadRequest();

        var existingUser = await  _userManager.FindByEmailAsync(registerUser.EmailAddress);
        if (existingUser is not null) return BadRequest(); //TODO: to change later

        IdentityUser user = new()
        {
            UserName = registerUser.UserName,
            Email = registerUser.EmailAddress,
            SecurityStamp = registerUser.UserName
        };
        var result = await _userManager.CreateAsync(user, registerUser.Password);

        if (!result.Succeeded) return BadRequest(result.Errors);

        return Created("", null);
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
    {
        var user = await _userManager.FindByEmailAsync(loginUser.Email);
        if (user is null || !await _userManager.CheckPasswordAsync(user, loginUser.Password)) return Unauthorized();

        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var jwtToken = GetToken(authClaims);

        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
            validTo = jwtToken.ValidTo
        });
    }

    [AllowAnonymous]
    [HttpGet("test")]
    public async Task<IActionResult> test()
    {
        return Ok("test");
    }

    private JwtSecurityToken GetToken(List<Claim> claims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Audience"],
            expires: DateTime.Now.AddHours(2),
            claims: claims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

        return token;
    }

}
