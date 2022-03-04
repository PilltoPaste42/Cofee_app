namespace CoffeeMachine.Core.Dto;

using System.ComponentModel.DataAnnotations;

/// <summary>
///     DTO для работы с таблицей MachineBanknote
/// </summary>
public class MachineBanknoteDto
{
    /// <summary>
    ///     Количество
    /// </summary>
    [Required]
    public int Count { get; set; }

    /// <summary>
    ///     Номинал банкноты
    /// </summary>
    [Required]
    public int Denomination { get; set; }
}