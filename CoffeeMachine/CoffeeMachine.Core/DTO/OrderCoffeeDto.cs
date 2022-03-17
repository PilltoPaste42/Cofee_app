namespace CoffeeMachine.Core.Dto;

using System.ComponentModel.DataAnnotations;

/// <summary>
///     DTO для работы с таблицей OrderCoffee
/// </summary>
public class OrderCoffeeDto
{
    /// <summary>
    ///     Кофе
    /// </summary>
    [Required]
    public CoffeeDto Coffee { get; set; }

    /// <summary>
    ///     Количество кофе
    /// </summary>
    [Required]
    public int Count { get; set; }
}