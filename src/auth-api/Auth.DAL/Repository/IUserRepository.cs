using Auth.Domain.Common.Result;
using Auth.Domain.Models;

namespace Auth.DAL.Repository;

public interface IUserRepository
{
    public Task<Result<User>> FindByEmailAsync(string Email);

    public Task<Result<User>> AuthenticateUser(string email, string password);

    public Task<Result<User>> CreateUserAsync(User user, string password);
}