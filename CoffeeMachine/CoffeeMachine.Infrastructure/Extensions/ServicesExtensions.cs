namespace CoffeeMachine.Infrastructure.Extensions;

using CoffeeMachine.Core.Interfaces.Services;
using CoffeeMachine.Infrastructure.Services;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
///     Класс расширения для регистрации сервисов
/// </summary>
public static class ServicesExtensions
{
    /// <summary>
    ///     Регистрация сервисов
    /// </summary>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICoffeeService, CoffeeService>();
        
        return services;
    }
}