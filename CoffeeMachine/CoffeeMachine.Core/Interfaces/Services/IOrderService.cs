namespace CoffeeMachine.Core.Interfaces.Services;

using CoffeeMachine.Core.Dto;

/// <summary>
///     Сервис для работы с таблицами Order и OrderCoffee
/// </summary>
public interface IOrderService
{
    /// <summary>
    ///     Создание заказа
    /// </summary>
    /// <param name="orderCreateDto"> DTO заказа </param>
    /// <returns> Сдача с оплаты заказа в виде списка банкнот </returns>
    Task<IEnumerable<MachineBanknoteDto>> CreateOrderAsync(OrderCreateDto orderCreateDto);

    /// <summary>
    ///     Получение всех заказов
    /// </summary>
    Task<IEnumerable<OrderReadDto>> GetOrdersAsync();
}