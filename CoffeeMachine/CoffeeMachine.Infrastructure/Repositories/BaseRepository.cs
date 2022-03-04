namespace CoffeeMachine.Infrastructure.Repositories;

using CoffeeMachine.Core.Exceptions;
using CoffeeMachine.Core.Interfaces.Repositories;

using Microsoft.EntityFrameworkCore;

/// <inheritdoc cref="IBaseRepository{T}"/> 
public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    /// <summary>
    ///     Таблица данных из контекста
    /// </summary>
    private readonly DbSet<T> _dbSet;

    protected BaseRepository(DbContext context)
    {
        _dbSet = context.Set<T>();
    }

    public async Task CreateAsync(T element)
    {
        await _dbSet.AddAsync(element);
    }

    public async Task DeleteAsync(int id)
    {
        var element = await _dbSet.FindAsync(id);
        if (element == null)
            throw new ObjectNotFoundException($"Ошибка при удалении. Запись с идентификатором {id} не найдена");

        _dbSet.Remove(element);
    }

    public Task<IQueryable<T>> GetAllAsync()
    {
        return Task.FromResult<IQueryable<T>>(_dbSet);
    }

    public async Task<T> GetAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task UpdateAsync(T element)
    {
        var isElementExist = await _dbSet.AnyAsync(p => p == element);
        if (!isElementExist)
            throw new ObjectNotFoundException($"Ошибка при обновлении. Запись не найдена");

        _dbSet.Update(element);
    }
}