namespace CoffeeMachine.Infrastructure.Extensions;

using CoffeeMachine.Infrastructure.AutoMapper;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
///     Класс расширения для автомаппера
/// </summary>
public static class AutoMapperExtensions
{
    /// <summary>
    ///     Регистрация автомаппера
    /// </summary>
    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        return services.AddAutoMapper(c => c.AddProfile(new MappingProfile()));
    }
}