namespace CoffeeMachine.Core.Dto;

using System.ComponentModel.DataAnnotations;

using CoffeeMachine.Core.Enums;

/// <summary>
///     DTO для работы с таблицами Orders и Coffee
/// </summary>
public class OrderDto : BaseDto
{
    /// <summary>
    ///     Баланс введённый пользователем
    /// </summary>
    [Required]
    public int Balance { get; set; }

    /// <summary>
    ///     Список кофе в заказе
    /// </summary>
    public IEnumerable<CoffeeDto> CoffeeList { get; set; }

    /// <summary>
    ///     Дата и время операции
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    ///     Статус выполнения заказа
    /// </summary>
    public OrderStatus Status { get; set; }

    /// <summary>
    ///      Общая стоимость заказа
    /// </summary>
    public int TotalCost { get; set; }
}