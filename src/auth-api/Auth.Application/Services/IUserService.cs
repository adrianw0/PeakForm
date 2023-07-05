using Auth.Application.Requests.Login;
using Auth.Application.Requests.Signup;
using Auth.Domain.Common.Result;

namespace Auth.Application.Services;

public interface IUserService
{
    public Task<Result<string>> LoginAsync(LoginUser loginUser);

    public Task<Result<string>> RegisterUserAsync(RegisterUser registerUser);
}