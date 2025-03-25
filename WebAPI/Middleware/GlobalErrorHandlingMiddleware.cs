using System.Text.Json;
using Application.Utils.ValidationErrors;

namespace WebAPI.Middleware;

public class GlobalErrorHandlingMiddleware(RequestDelegate next, IEnumerable<IValidationErrorStrategy> errors)
{
    private readonly RequestDelegate _next = next;
    private readonly IEnumerable<IValidationErrorStrategy> _errors = errors;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandlerExceptionAsync(context, ex);
        }
    }

    private async Task<Task> HandlerExceptionAsync(HttpContext context, Exception exception)
    {
        InternalErrorModel internalError = new();

        foreach (var error in _errors)
        {
            var ex = error.Validate(exception);

            if (ex.Message is not null) internalError = ex;
        }

        var result = JsonSerializer.Serialize(new { internalError.StatusCode, internalError.Info, internalError.Message });

        context.Response.ContentType = "text/json";
        context.Response.StatusCode = (int)internalError.StatusCode;

        return context.Response.WriteAsync(result);
    }
}