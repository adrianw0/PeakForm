namespace Auth.DAL.Exceptions;

#pragma warning disable S3925 // "ISerializable" should be implemented correctly
public class UserCreationException : Exception
#pragma warning restore S3925 // "ISerializable" should be implemented correctly
{
    public string Errors { get; }

    public UserCreationException(string errors)
    {
        Errors = errors;
    }
}