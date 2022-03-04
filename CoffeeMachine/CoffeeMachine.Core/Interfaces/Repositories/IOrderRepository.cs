namespace CoffeeMachine.Core.Interfaces.Repositories;

using CoffeeMachine.Core.Models;

/// <summary>
///     Репозиторий для работы с таблицами Order и OrderCoffee
/// </summary>
public interface IOrderRepository : IBaseRepository<Order>
{
    /// <summary>
    ///     Добавление кофе в заказ
    /// </summary>
    /// <param name="orderId"> Идентификатор заказа </param>
    /// <param name="coffeeId"> Идентификатор кофе </param>
    /// <param name="count"> Количество кофе </param>
    Task AddCoffeeInOrderAsync(int orderId, int coffeeId, int count);

    /// <summary> Удаление кофе из заказа </summary>
    /// <param name="orderId"> Идентификатор заказа </param>
    /// <param name="coffeeId"> Идентификатор кофе </param>
    Task DeleteCoffeeFromOrderAsync(int orderId, int coffeeId);

    /// <summary> Обновление количества кофе в заказе </summary>
    /// <param name="orderId"> Идентификатор заказа </param>
    /// <param name="coffeeId"> Идентификатор кофе </param>
    /// <param name="count"> Новое количество кофе </param>
    Task UpdateCoffeeCountAsync(int orderId, int coffeeId, int count);
}