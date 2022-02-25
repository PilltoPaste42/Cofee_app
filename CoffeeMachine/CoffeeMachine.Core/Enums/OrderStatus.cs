namespace CoffeeMachine.Core.Enums
{
    /// <summary>
    ///     Статус заказа кофе
    /// </summary>
    public enum OrderStatus : short
    {
        /// <summary>
        ///     Успешное выполнение заказа
        /// </summary>
        Success = 0,

        /// <summary>
        ///     Заказ отменен
        /// </summary>
        Сanceled = -1,

        /// <summary>
        ///     Заказ в процессе оформления
        /// </summary>
        InProcess = 1
    }
}