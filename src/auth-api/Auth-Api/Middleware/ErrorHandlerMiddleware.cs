using Auth.DAL.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace Auth_Api.Middleware;

public class ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger = logger;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var errors = "";
            if (ex is UserCreationException userCreationException)
            {
                errors = $"{userCreationException.Errors}";
            }

            _logger.LogCritical(ex, "An unhandled exception has occurred while executing the request: {errors}", errors );
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