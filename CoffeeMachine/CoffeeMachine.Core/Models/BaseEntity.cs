namespace CoffeeMachine.Core.Models;

using System.ComponentModel.DataAnnotations;

/// <summary>
///     Базовый класс для реализации моделей таблиц
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    ///     Идентификатор записи
    /// </summary>
    [Key]
    public int Id { get; set; }
}
