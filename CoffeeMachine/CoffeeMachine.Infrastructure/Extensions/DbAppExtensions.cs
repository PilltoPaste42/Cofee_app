namespace CoffeeMachine.Infrastructure.Extensions
{
    using CoffeeMachine.Core.Interfaces.Repositories;
    using CoffeeMachine.Core.Interfaces.UoW;
    using CoffeeMachine.Infrastructure.Data;
    using CoffeeMachine.Infrastructure.Repositories;
    using CoffeeMachine.Infrastructure.UoW;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    ///     Класс расширения для работы с БД
    /// </summary>
    public static class DbAppExtensions
    {
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
    }
}