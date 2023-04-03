

namespace ToDoList.Infrastructure.Middleware;

public class ExceptionMiddleware : IMiddleware
{
    private record Error(string Code, string Reason);
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(exception, context);
        }
    }

    private async Task HandleExceptionAsync(Exception exception, HttpContext context)
    {
        var (statusCode, error) = exception switch
        {
            CustomException => 
            (
                StatusCodes.Status400BadRequest, new Error
                (
                    exception.GetType().Name.Replace("Exception", string.Empty), exception.Message
                )
            ),
            _ => 
            (
                StatusCodes.Status500InternalServerError, new Error
                (
                    "Error", "Internal Server Error"
                )
            )
        };

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(error);
    }
}