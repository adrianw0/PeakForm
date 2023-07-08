namespace Auth.DAL.Exceptions;

public class UserCreationException : Exception
{
    public string Errors { get; }

    public UserCreationException(string errors)
    {
        Errors = errors;
    }
}