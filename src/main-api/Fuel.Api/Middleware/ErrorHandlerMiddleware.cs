using Newtonsoft.Json;
using System.Net;
using System.Security;

namespace Fuel.Api.Middleware;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;
    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            const string logMessage = "An unhandled exception has occurred while executing the request.";
            var request = context.Request;

            _logger.LogCritical(ex,
               "{LogMessage} | Path: {Path}, Method: {Method}, Query: {QueryString}",
               logMessage, request.Path, request.Method, request.QueryString);

            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode code = GetStatusCode(exception);

        var result = JsonConvert.SerializeObject(new { error = exception.Message }); ///TODO: shouldn't be like that on prod.

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }
    private static HttpStatusCode GetStatusCode(Exception exception)
    {
        return exception switch
        {
            ArgumentException => HttpStatusCode.BadRequest,
            InvalidOperationException => HttpStatusCode.BadRequest,
            UnauthorizedAccessException => HttpStatusCode.Unauthorized,
            SecurityException => HttpStatusCode.Forbidden,
            KeyNotFoundException => HttpStatusCode.NotFound,
            FileNotFoundException => HttpStatusCode.NotFound,
            DirectoryNotFoundException => HttpStatusCode.NotFound,
            InvalidDataException => HttpStatusCode.UnprocessableEntity,
            TimeoutException => HttpStatusCode.RequestTimeout,
            OperationCanceledException => (HttpStatusCode)499,
            NotSupportedException => HttpStatusCode.NotImplemented,
            HttpRequestException => HttpStatusCode.BadGateway,
            _ => HttpStatusCode.InternalServerError, 
        };
    }
}

