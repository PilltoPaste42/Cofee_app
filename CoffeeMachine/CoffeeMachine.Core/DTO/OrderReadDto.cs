namespace CoffeeMachine.Core.Dto;

/// <summary>
///     DTO для работы с таблицами Orders и Coffee
/// </summary>
public class OrderReadDto : BaseDto
{
    /// <summary>
    ///     Список кофе в заказе
    /// </summary>
    public IEnumerable<OrderCoffeeDto> CoffeeList { get; set; }

    /// <summary>
    ///     Дата и время операции
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    ///      Общая стоимость заказа
    /// </summary>
    public int TotalCost { get; set; }
}