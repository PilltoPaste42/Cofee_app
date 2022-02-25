namespace CoffeeMachine.Infrastructure
{
    using CoffeeMachine.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    ///     Класс расширения для работы с БД
    /// </summary>
    public static class DbAppExtensions
    {
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