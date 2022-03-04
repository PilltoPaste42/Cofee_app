namespace CoffeeMachine.Core.Interfaces.Repositories;

using CoffeeMachine.Core.Models;

/// <summary>
///     Репозиторий для работы с таблицей MachineBanknote
/// </summary>
public interface IMachineBanknoteRepository : IBaseRepository<MachineBanknote>
{
    /// <summary>
    ///     Извлечение всех средств из автомата
    /// </summary>
    Task CleanAsync();

    /// <summary>
    ///     Введение средств
    /// </summary>
    /// <param name="banknotes"> Список банкнот </param>
    Task CreateRangeAsync(IEnumerable<MachineBanknote> banknotes);

    /// <summary>
    ///     Обновление банкнот в аппарате
    /// </summary>
    /// <param name="banknotes"> Список банкнот </param>
    Task UpdateRangeAsync(IEnumerable<MachineBanknote> banknotes);
}