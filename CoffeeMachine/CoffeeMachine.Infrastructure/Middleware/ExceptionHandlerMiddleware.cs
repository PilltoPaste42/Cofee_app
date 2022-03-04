namespace CoffeeMachine.Infrastructure.Middleware;

using CoffeeMachine.Core.Exceptions;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

/// <summary>
///     Обработчик исключений 
/// </summary>
public class ExceptionHandlerMiddleware
{
    /// <summary>
    ///     Логгер
    /// </summary>
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    /// <summary>
    ///     Делегат запроса
    /// </summary>
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    ///     Вызов делегата с обработкой исключений
    /// </summary>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ObjectNotFoundException e)
        {
            _logger.LogError(e, e.Message);
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsync(e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync("Неизвестная ошибка на стороне сервера");
        }
    }
}