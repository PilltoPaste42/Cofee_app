namespace CoffeeMachine.Core.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     Модель для связи М-М между Order и Coffee
    /// </summary>
    public class OrderCoffee
    {
        /// <summary>
        ///     Кофе 
        /// </summary>
        [Required]
        public Coffee Coffee { get; set; }

        /// <summary>
        ///     Идентификатор позиции кофе
        /// </summary>
        [Required]
        public int CoffeeId { get; set; }

        /// <summary>
        ///     Количество позиций кофе
        /// </summary>
        [Required]
        public int Count { get; set; }

        /// <summary>
        ///     Экземпляр заказа
        /// </summary>
        [Required]
        public Order Order { get; set; }

        /// <summary>
        ///     Идентификатор заказа
        /// </summary>
        [Required]
        public int OrderId { get; set; }
    }
}