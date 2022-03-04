namespace CoffeeMachine.Core.Interfaces.Services;

/// <summary>
///     Базовый сервис реализующий CRUD
/// </summary>
public interface IBaseService<TDto> where TDto : class
{
    /// <summary>
    ///     Добавление элемента
    /// </summary>
    /// <param name="element"> Добавляемый в бд элемент </param>
    Task CreateAsync(TDto element);

    /// <summary>
    ///     Удаление элемента
    /// </summary>
    /// <param name="id"> Идентификатор элемента </param>
    Task DeleteAsync(int id);

    /// <summary>
    ///     Получение всех элементов
    /// </summary>
    Task<IEnumerable<TDto>> GetAllAsync();

    /// <summary>
    ///     Получение элемента
    /// </summary>
    /// <param name="id"> Идентификатор элемента </param>
    Task<TDto> GetAsync(int id);

    /// <summary>
    ///     Обновление элемента
    /// </summary>
    /// <param name="element"> Новый элемент </param>
    Task UpdateAsync(TDto element);
}