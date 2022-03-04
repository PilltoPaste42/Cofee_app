namespace CoffeeMachine.Core.Dto;

using System.ComponentModel.DataAnnotations;

/// <summary>
///     DTO для работы с таблицей Coffee
/// </summary>
public class CoffeeDto : BaseDto
{
    /// <summary>
    ///     Наименование
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    ///     Цена напитка
    /// </summary>
    [Required]
    public uint Price { get; set; }
}