namespace CoffeeMachine.Core.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     Модель таблицы кофе
    /// </summary>
    public class Coffee : BaseEntity
    {
        /// <summary>
        ///     Наименование
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        ///     Навигационное свойство для связи с Order
        /// </summary>
        public List<OrderCoffee> OrderCoffee { get; set; }

        /// <summary>
        ///     Цена напитка
        /// </summary>
        [Required]
        public uint Price { get; set; }
    }
}