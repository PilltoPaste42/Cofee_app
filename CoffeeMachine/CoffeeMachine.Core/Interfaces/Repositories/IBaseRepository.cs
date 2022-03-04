namespace CoffeeMachine.Core.Interfaces.Repositories;

/// <summary>
///     Базовый репозиторий реализующий CRUD
/// </summary>
public interface IBaseRepository<T> where T : class
{
    /// <summary>
    ///     Добавление элемента
    /// </summary>
    /// <param name="element"> Добавляемый в бд элемент </param>
    Task CreateAsync(T element);

    /// <summary>
    ///     Удаление элемента
    /// </summary>
    /// <param name="id"> Идентификатор элемента </param>
    Task DeleteAsync(int id);

    /// <summary>
    ///     Получение всех элементов
    /// </summary>
    Task<IQueryable<T>> GetAllAsync();

    /// <summary>
    ///     Получение элемента
    /// </summary>
    /// <param name="id"> Идентификатор элемента </param>
    Task<T> GetAsync(int id);

    /// <summary>
    ///     Обновление элемента
    /// </summary>
    /// <param name="element"> Новый элемент </param>
    Task UpdateAsync(T element);
}