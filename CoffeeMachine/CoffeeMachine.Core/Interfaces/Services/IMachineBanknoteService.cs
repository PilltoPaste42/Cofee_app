namespace CoffeeMachine.Core.Interfaces.Services;

using CoffeeMachine.Core.Dto;

/// <summary>
///     Сервис для работы с таблицей MachineBanknotes
/// </summary>
public interface IMachineBanknoteService : IBaseService<MachineBanknoteDto>
{
    /// <summary>
    ///     Извлечение всех средств из автомата
    /// </summary>
    Task CleanAsync();

    /// <summary>
    ///     Введение средств
    /// </summary>
    /// <param name="banknotes"> Список банкнот </param>
    Task CreateRangeAsync(IEnumerable<MachineBanknoteDto> banknotes);

    /// <summary>
    ///     Обновление банкнот в аппарате
    /// </summary>
    /// <param name="banknotes"> Список банкнот </param>
    Task UpdateRangeAsync(IEnumerable<MachineBanknoteDto> banknotes);
}