namespace Auth.DAL.Exceptions;

public class UserCreationException(string errors) : Exception
{
    public string Errors { get; } = errors;
}