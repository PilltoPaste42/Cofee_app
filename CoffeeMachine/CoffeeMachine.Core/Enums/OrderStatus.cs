namespace CoffeeMachine.Core.Enums
{
    // Перечисление для статуса выполнение заказа кофе
    public enum OrderStatus : short
    {
        Success = 0,
        Error = -1,
        InProcess = 1
    }
}