namespace CoffeeMachine.Infrastructure.Extensions;

using CoffeeMachine.Infrastructure.Middleware;

using Microsoft.AspNetCore.Builder;

/// <summary>
///     Класс расширения для подключения middleware
/// </summary>
public static class RegisterMiddleware
{
    /// <summary>
    ///     Регистрация обработчика исключений
    /// </summary>
    public static IApplicationBuilder UseAppExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}