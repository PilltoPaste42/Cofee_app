namespace CoffeeMachine.Core.Dto;

using System.ComponentModel.DataAnnotations;

/// <summary>
///     DTO для создания заказа
/// </summary>
public class OrderCreateDto
{
    /// <summary>
    ///     Список кофе в заказе
    /// </summary>
    [Required]
    public IEnumerable<OrderCoffeeDto> CoffeeList { get; set; }
    
    /// <summary>
    ///     Список внесенных банкнот
    /// </summary>
    [Required]
    public IEnumerable<MachineBanknoteDto> Banknotes { get; set; }
}