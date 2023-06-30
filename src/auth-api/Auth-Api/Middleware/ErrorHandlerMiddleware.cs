using Auth.DAL.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace Auth_Api.Middleware;

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
            string logMessage = "An unhandled exception has occurred while executing the request.";

            if(ex is UserCreationException userCreationException)
            {
                logMessage += $"{userCreationException.Errors}";
            }

            _logger.LogCritical(ex, logMessage);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;

        if (exception is UserCreationException) code = HttpStatusCode.BadRequest;

   
        var result = JsonConvert.SerializeObject(new { error = exception.Message });

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }
}

