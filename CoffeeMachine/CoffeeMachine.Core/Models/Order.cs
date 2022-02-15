namespace CoffeeMachine.Core.Models
{
    using System.ComponentModel.DataAnnotations;

    // Модель таблицы заказов
    public class Order : BaseEntity
    {
        [Required]
        public int Balance { get; set; } // Значение введенных средств

        [Required]
        public DateTime Date { get; set; } // Дата и время операции. Обновляется в месте со статусом

        [Required]
        public int Status { get; set; } // Статус выполнения заказа

        [Required]
        public int TotalCost { get; set; } // Конченая стоимость заказа

        public  List<OrderCoffee> OrderCoffee { get; set; } // Навигационное свойство для связи с Coffee
    }
}