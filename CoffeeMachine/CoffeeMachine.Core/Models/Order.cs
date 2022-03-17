namespace CoffeeMachine.Core.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     Модель таблицы заказов
    /// </summary>
    public class Order : BaseEntity
    {
        /// <summary>
        ///     Дата и время операции
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        ///     Навигационное свойство для связи с Coffee
        /// </summary>
        public List<OrderCoffee> OrderCoffee { get; set; }

        /// <summary>
        ///      Общая стоимость заказа
        /// </summary>
        [Required]
        public int TotalCost { get; set; }
    }
}