namespace CoffeeMachine.Core.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     Модель таблицы для хранения данных о банкнотах в кофейном автомате
    /// </summary>
    public class MachineBanknote
    {
        /// <summary>
        ///     Количество
        /// </summary>
        [Required]
        public int Count { get; set; }

        /// <summary>
        ///     Номинал банкноты
        /// </summary>
        [Key]
        public int Denomination { get; set; }
    }
}