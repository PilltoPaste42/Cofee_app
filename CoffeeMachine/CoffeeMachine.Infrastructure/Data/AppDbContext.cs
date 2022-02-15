namespace CoffeeMachine.Infrastructure.Data
{
    using CoffeeMachine.Core.Models;

    using Microsoft.EntityFrameworkCore;

    // Создание класса контекста для БД
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Объявление таблиц БД из моделей
        public DbSet<Coffee> Coffee { get; set; }
        public DbSet<MachineBanknote> MachineBanknotes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderCoffee> OrdersCoffee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Применение конфигураций таблиц
            // Конфигурация реализована в CoffeeMachine.Infrastructure.EntityTypeConfigurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}