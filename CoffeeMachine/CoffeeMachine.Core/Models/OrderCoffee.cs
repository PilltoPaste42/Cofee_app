namespace CoffeeMachine.Core.Models
{
    using System.ComponentModel.DataAnnotations;

    // Модель для обеспечения связи М-М между Order и Coffee  
    public class OrderCoffee
    {
        [Required]
        public int CoffeeId { get; set; } // PFK
        [Required]
        public Coffee Coffee { get; set; }
        [Required]
        public int OrderId { get; set; } // PFK
        [Required]
        public Order Order { get; set; }

        [Required]
        public int Count { get; set; } // Количество кофе 
    }
}