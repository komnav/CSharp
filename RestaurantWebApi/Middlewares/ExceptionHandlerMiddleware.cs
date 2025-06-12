using System.Net;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Npgsql;
using RestaurantWeb.DTOs;

namespace RestaurantWeb.Middlewares;

public class ExceptionHandlerMiddleware(
    RequestDelegate next,
    IWebHostEnvironment env,
    ILogger<ExceptionHandlerMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly IWebHostEnvironment _env = env;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandlerExceptionAsync(context, e);
        }
    }

    private async Task HandlerExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        var message = _env.IsProduction() ? "Internal Server Error" : GetMessageDetails(exception);

        if (IsPostgresDuplicateException(exception))
        {
            code = HttpStatusCode.Conflict;
            message = "Duplicate data was added.";
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        var errorResponse = new ErrorResponseModel((int)code, message);
        await context.Response.WriteAsJsonAsync(errorResponse);

        if (code == HttpStatusCode.InternalServerError)
        {
            _logger.LogError(exception, message);
        }
    }

    bool IsPostgresDuplicateException(Exception exception)
    {
        while (exception != null)
        {
            if (exception is PostgresException postgresException &&
                postgresException.SqlState == PostgresErrorCodes.UniqueViolation)
            {
                return true;
            }

            exception = exception.InnerException;
        }

        return false;
    }

    string GetMessageDetails(Exception exception)
    {
        StringBuilder messageBuilder = new StringBuilder();

        while (exception != null)
        {
            messageBuilder.AppendLine(exception.Message);
            exception = exception.InnerException;
        }

        return messageBuilder.ToString();
    }
}