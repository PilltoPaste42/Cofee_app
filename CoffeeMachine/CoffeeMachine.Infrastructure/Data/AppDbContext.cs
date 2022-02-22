namespace CoffeeMachine.Infrastructure.Data
{
    using CoffeeMachine.Core.Models;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    ///     Класс контекста базы данных приложения
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <inheritdoc />
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        ///     Таблица Coffee
        /// </summary>
        public DbSet<Coffee> Coffee { get; set; }

        /// <summary>
        ///     Таблица MachineBanknotes
        /// </summary>
        public DbSet<MachineBanknote> MachineBanknotes { get; set; }

        /// <summary>
        ///     Таблица Orders
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        ///     Таблица OrdersCoffee
        /// </summary>
        public DbSet<OrderCoffee> OrdersCoffee { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}