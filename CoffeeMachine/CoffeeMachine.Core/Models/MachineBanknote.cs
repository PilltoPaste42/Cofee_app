namespace CoffeeMachine.Core.Models
{
    using System.ComponentModel.DataAnnotations;

    // Модель таблицы для хранения данных о банкнотах в кофейном автомате
    public class MachineBanknote
    {
        [Required]
        public int Count { get; set; }

        [Key]
        public int Denomination { get; set; } // Значение наминала банкноты (PK) 
    }
}