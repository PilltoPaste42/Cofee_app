namespace CoffeeMachine.Core.Dto;

using System.ComponentModel.DataAnnotations;

/// <summary>
///     DTO для работы с таблицами Orders и Coffee
/// </summary>
public class OrderReadDto : BaseDto
{
    /// <summary>
    ///     Список кофе в заказе
    /// </summary>
    [Required]
    public IEnumerable<OrderCoffeeDto> CoffeeList { get; set; }

    /// <summary>
    ///     Дата и время операции
    /// </summary>
    [Required]
    public DateTime Date { get; set; }

    /// <summary>
    ///      Общая стоимость заказа
    /// </summary>
    [Required]
    public int TotalCost { get; set; }
}