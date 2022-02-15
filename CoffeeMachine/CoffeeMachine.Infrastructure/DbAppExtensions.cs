namespace CoffeeMachine.Infrastructure
{
    using CoffeeMachine.Infrastructure.Data;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    // Статический класс и реализация метода расширения от IHost
    // для обеспечения автоматической миграции данных в БД
    public static class DbAppExtensions
    {
        public static IHost InitDb(this IHost app)
        {
            using var scope = app.Services.CreateScope();

            using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            context.Database.Migrate();


            return app;
        }
    }
}