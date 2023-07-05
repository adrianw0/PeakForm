namespace Auth.Domain.Common.Result;

public class Result
{
    public bool Success { get; }
    public string ErrorMessage { get; }

    protected Result(bool success, string errorMessage) => (Success, ErrorMessage) = (success, errorMessage);

    public static Result Fail(string message) => new(false, message);

    public static Result<T> Fail<T>(string message) => new(default, false, message);

    public static Result Ok() => new(true, string.Empty);

    public static Result<T> Ok<T>(T value) => new(value, true, string.Empty);
}

public class Result<T> : Result
{
    public T Value { get; }

    protected internal Result(T value, bool success, string errorMessage) : base(success, errorMessage)
    {
        Value = value;
    }
}