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
        await _machineBanknote.AddRangeAsync(banknotes);
    }

    public async Task UpdateRangeAsync(IEnumerable<MachineBanknote> banknotes)
    {
        var notFoundDenominations = string.Empty;
        foreach (var banknote in banknotes)
        {
            if (!await _machineBanknote.AnyAsync(p => p.Denomination == banknote.Denomination))
                notFoundDenominations += banknote.Denomination + ", ";
        }

        if (notFoundDenominations.Length > 0)
        {
            notFoundDenominations = notFoundDenominations.Trim(' ', ',');
            throw new ObjectNotFoundException("Ошибка при обновлении множества банкнот. " +
                                              $"Банкнота(ы) с номиналом {notFoundDenominations} не найдена");
        }
        
        _machineBanknote.UpdateRange(banknotes);
    }
}
