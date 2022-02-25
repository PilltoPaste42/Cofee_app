namespace CoffeeMachine.Infrastructure.Repositories;

using System.Data.Entity.Core;

using CoffeeMachine.Core.Interfaces.Repositories;
using CoffeeMachine.Core.Models;
using CoffeeMachine.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

/// <inheritdoc cref="IOrderRepository"/>
public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    /// <summary>
    ///     Таблица Coffee из контекста
    /// </summary>
    private readonly DbSet<Coffee> _coffee;

    /// <summary>
    ///     Таблица Order из контекста
    /// </summary>
    private readonly DbSet<Order> _order;

    /// <summary>
    ///     Таблица OrderCoffee из контекста
    /// </summary>
    private readonly DbSet<OrderCoffee> _orderCoffee;

    public OrderRepository(AppDbContext context) : base(context)
    {
        _orderCoffee = context.Set<OrderCoffee>();
        _order = context.Set<Order>();
        _coffee = context.Set<Coffee>();
    }

    public async Task AddCoffeeInOrderAsync(int orderId, int coffeeId, int count)
    {
        if (!await _order.AnyAsync(p => p.Id == orderId))
            throw new ObjectNotFoundException($"Ошибка при добавлении кофе в заказ. Заказ с идентификатором {orderId} не найден");

        if (!await _coffee.AnyAsync(p => p.Id == coffeeId))
            throw new ObjectNotFoundException($"Ошибка при добавлении кофе в заказ. Кофе с идентификатором {coffeeId} не найден");

        var element = new OrderCoffee
        {
            CoffeeId = coffeeId,
            OrderId = orderId,
            Count = count
        };

        await _orderCoffee.AddAsync(element);
    }

    public async Task DeleteCoffeeFromOrderAsync(int orderId, int coffeeId)
    {
        var element = await _orderCoffee.FindAsync(orderId, coffeeId);
        if (element == null)
            throw new ObjectNotFoundException("Ошибка при удалении кофе из заказа. Указанный кофе в заказе не найден");

        _orderCoffee.Remove(element);
    }

    public async Task UpdateCoffeeCountAsync(int orderId, int coffeeId, int count)
    {
        var element = await _orderCoffee.FindAsync(orderId, coffeeId);
        if (element == null)
            throw new ObjectNotFoundException("Ошибка при обновлении кофе в заказе. Указанный кофе в заказе не найден");

        element.Count = count;

        _orderCoffee.Update(element);
    }
}