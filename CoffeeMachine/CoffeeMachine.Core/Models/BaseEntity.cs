namespace CoffeeMachine.Core.Models;

using System.ComponentModel.DataAnnotations;
// Шаблон для создания моделей таблиц
public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; } // Ключевое поле (PK)
}