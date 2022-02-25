namespace CoffeeMachine.Infrastructure.EntityTypeConfigurations;

using CoffeeMachine.Core.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
///     Конфигурация таблицы OrderCoffee 
/// </summary>
public class OrderCoffeeEntityTypeConfiguration : IEntityTypeConfiguration<OrderCoffee>
{
    /// <inheritdoc cref="IEntityTypeConfiguration{TEntity}.Configure"/>
    public void Configure(EntityTypeBuilder<OrderCoffee> builder)
    {
        builder.HasKey(b => new { b.CoffeeId, b.OrderId });

        builder
            .HasOne(p => p.Coffee)
            .WithMany(d => d.OrderCoffee)
            .HasForeignKey(c => c.CoffeeId);
        builder
            .HasOne(p => p.Order)
            .WithMany(d => d.OrderCoffee)
            .HasForeignKey(c => c.OrderId);
    }
}