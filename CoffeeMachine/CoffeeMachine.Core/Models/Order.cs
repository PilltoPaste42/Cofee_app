namespace CoffeeMachine.Core.Models
{
    using System.ComponentModel.DataAnnotations;
    using CoffeeMachine.Core.Enums;

    /// <summary>
    ///     Модель таблицы заказов
    /// </summary>
    public class Order : BaseEntity
    {
        /// <summary>
        ///     Баланс введённый пользователем
        /// </summary>
        [Required]
        public int Balance { get; set; }

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
        ///     Статус выполнения заказа
        /// </summary>
        [Required]
        public OrderStatus Status { get; set; }

        /// <summary>
        ///      Общая стоимость заказа
        /// </summary>
        [Required]
        public int TotalCost { get; set; }
    }
}