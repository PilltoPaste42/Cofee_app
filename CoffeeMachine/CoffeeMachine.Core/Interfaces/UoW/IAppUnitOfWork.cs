namespace CoffeeMachine.Core.Interfaces.UoW;

using CoffeeMachine.Core.Interfaces.Repositories;

/// <summary>
///     Единица работы с репозиториями
/// </summary>
public interface IAppUnitOfWork
{
    /// <inheritdoc cref="ICoffeeRepository"/>
    ICoffeeRepository Coffee { get; }

    /// <inheritdoc cref="IMachineBanknoteRepository"/>
    IMachineBanknoteRepository MachineBanknotes { get; }

    /// <inheritdoc cref="IOrderRepository"/>
    IOrderRepository Orders { get; }

    /// <summary>
    ///     Сохранение изменений в БД
    /// </summary>
    Task CommitAsync();
}