namespace CoffeeMachine.Infrastructure.Middleware;

using System.ComponentModel.DataAnnotations;

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
            await HandleException(context, StatusCodes.Status404NotFound, e.Message);
        }
        catch (ObjectAlreadyExistsException e)
        {
            _logger.LogError(e, e.Message);
            await HandleException(context, StatusCodes.Status400BadRequest, e.Message);
        }
        catch (ValidationException e)
        {
            _logger.LogError(e, e.Message);
            await HandleException(context, StatusCodes.Status400BadRequest, e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            await HandleException(context,
                StatusCodes.Status500InternalServerError,
                "Неизвестная ошибка на стороне сервера");
        }
    }

    /// <summary>
    ///     Настройка ответа на исключение
    /// </summary>
    private static async Task HandleException(HttpContext context, int statusCode, string message)
    {
        context.Response.ContentType = "text/plain";
        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsync(message);
    }
}