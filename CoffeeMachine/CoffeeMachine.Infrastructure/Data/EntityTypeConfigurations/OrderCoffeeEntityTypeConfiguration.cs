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
        builder.HasKey(orderCoffee => new { orderCoffee.CoffeeId, orderCoffee.OrderId });

        builder
            .HasOne(orderCoffee => orderCoffee.Coffee)
            .WithMany(coffee => coffee.OrderCoffee)
            .HasForeignKey(orderCoffee => orderCoffee.CoffeeId);
        builder
            .HasOne(orderCoffee => orderCoffee.Order)
            .WithMany(order => order.OrderCoffee)
            .HasForeignKey(orderCoffee => orderCoffee.OrderId);
    }
}