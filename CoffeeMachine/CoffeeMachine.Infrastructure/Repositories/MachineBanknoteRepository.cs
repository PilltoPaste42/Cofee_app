namespace CoffeeMachine.Infrastructure.Repositories;

using CoffeeMachine.Core.Exceptions;
using CoffeeMachine.Core.Interfaces.Repositories;
using CoffeeMachine.Core.Models;
using CoffeeMachine.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

/// <inheritdoc cref="IMachineBanknoteRepository"/>
public class MachineBanknoteRepository : BaseRepository<MachineBanknote>, IMachineBanknoteRepository
{
    /// <summary>
    ///     Таблица MachineBanknote из контекста
    /// </summary>
    private readonly DbSet<MachineBanknote> _machineBanknote;

    public MachineBanknoteRepository(AppDbContext context) : base(context)
    {
        _machineBanknote = context.Set<MachineBanknote>();
    }

    public Task CleanAsync()
    {
        _machineBanknote.RemoveRange(_machineBanknote);
        return Task.CompletedTask;
    }

    public async Task CreateRangeAsync(IEnumerable<MachineBanknote> banknotes)
    {
        var existDenominationList = banknotes
            .Where(banknote =>
                _machineBanknote.Any(machineBanknote => machineBanknote.Denomination == banknote.Denomination))
            .Select(banknote => banknote.Denomination)
            .ToList();

        if (existDenominationList.Count > 0)
        {
            var existDenominationsString = string.Join(", ", existDenominationList);
            throw new ObjectAlreadyExistsException("Ошибка при добавлении множества банкнот. " +
                                              $"Банкнота(ы) с номиналом {existDenominationsString} уже существуют");
        }

        await _machineBanknote.AddRangeAsync(banknotes);
    }

    public Task UpdateRangeAsync(IEnumerable<MachineBanknote> banknotes)
    {
        var notFoundDenominationsList = banknotes
            .Where(banknote =>
                !_machineBanknote.Any(machineBanknote => machineBanknote.Denomination == banknote.Denomination))
            .Select(banknote => banknote.Denomination)
            .ToList();

        if (notFoundDenominationsList.Count > 0)
        {
            var notFoundDenominationsString = string.Join(", ", notFoundDenominationsList);
            throw new ObjectNotFoundException("Ошибка при обновлении множества банкнот. " +
                                              $"Банкнота(ы) с номиналом {notFoundDenominationsString} не найдена");
        }

        _machineBanknote.UpdateRange(banknotes);
        return Task.CompletedTask;
    }
}