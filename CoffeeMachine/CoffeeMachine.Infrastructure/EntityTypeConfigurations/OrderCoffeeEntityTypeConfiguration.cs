namespace CoffeeMachine.Infrastructure.EntityTypeConfigurations;

using CoffeeMachine.Core.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// Класс для конфигурации таблицы OrderCoffee 
public class OrderCoffeeEntityTypeConfiguration : IEntityTypeConfiguration<OrderCoffee>
{
    public void Configure(EntityTypeBuilder<OrderCoffee> builder)
    {
        // Обозначение составного ключа таблицы
        builder.HasKey(b => new { b.CoffeeId, b.OrderId });

        // Обозначение двух связей О-М, которые эквивалентны связи М-М 
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