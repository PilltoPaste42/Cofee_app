namespace CoffeeMachine.Infrastructure.Extensions;

using CoffeeMachine.Core.Interfaces.Repositories;
using CoffeeMachine.Core.Interfaces.Services;
using CoffeeMachine.Core.Interfaces.UoW;
using CoffeeMachine.Infrastructure.AutoMapper;
using CoffeeMachine.Infrastructure.Data;
using CoffeeMachine.Infrastructure.Middleware;
using CoffeeMachine.Infrastructure.Repositories;
using CoffeeMachine.Infrastructure.Services;
using CoffeeMachine.Infrastructure.UoW;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

/// <summary>
///     Класс расширения приложения
/// </summary>
public static class AppExtensions
{
    /// <summary>
    ///     Регистрация автомаппера
    /// </summary>
    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        return services.AddAutoMapper(expression => expression.AddProfile(new MappingProfile()));
    }

    /// <summary>
    ///     Регистрация сервисов
    /// </summary>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICoffeeService, CoffeeService>();
        services.AddScoped<IMachineBanknoteService, MachineBanknoteService>();
        services.AddScoped<IOrderService, OrderService>();

        return services;
    }

    /// <summary>
    ///     Регистрация репозиториев и uow
    /// </summary>
    public static IServiceCollection AddUnitOfWorkAndRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICoffeeRepository, CoffeeRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IMachineBanknoteRepository, MachineBanknoteRepository>();

        services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();

        return services;
    }

    /// <summary>
    ///     Выполнение миграции таблиц в БД
    /// </summary>
    public static IHost InitDb(this IHost app)
    {
        using var scope = app.Services.CreateScope();

        using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        context.Database.Migrate();

        return app;
    }

    /// <summary>
    ///     Регистрация обработчика исключений
    /// </summary>
    public static IApplicationBuilder UseAppExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}