namespace CoffeeMachine.Core.Models
{
    using System.ComponentModel.DataAnnotations;

    // Модель таблицы которая хранит позиции меню в кофейном аппарате
    public class Coffee : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public uint Price { get; set; }

        public  List<OrderCoffee> OrderCoffee { get; set; } // Навигационное свойство для связи с Order
    }
}