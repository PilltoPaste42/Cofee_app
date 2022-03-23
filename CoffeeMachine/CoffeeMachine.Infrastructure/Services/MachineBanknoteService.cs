namespace CoffeeMachine.Infrastructure.Services;

using CoffeeMachine.Core.Dto;
using CoffeeMachine.Core.Exceptions;
using CoffeeMachine.Core.Interfaces.Services;
using CoffeeMachine.Core.Interfaces.UoW;
using CoffeeMachine.Core.Models;

using global::AutoMapper;

/// <inheritdoc cref="IMachineBanknoteService"/>     
public class MachineBanknoteService : IMachineBanknoteService
{
    private readonly IMapper _mapper;
    private readonly IAppUnitOfWork _unit;

    public MachineBanknoteService(IAppUnitOfWork unit, IMapper mapper)
    {
        _mapper = mapper;
        _unit = unit;
    }

    public async Task CreateAsync(MachineBanknoteDto element)
    {
        var mappedElement = _mapper.Map<MachineBanknote>(element);
        await _unit.MachineBanknotes.CreateAsync(mappedElement);

        await _unit.CommitAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unit.MachineBanknotes.DeleteAsync(id);
        await _unit.CommitAsync();
    }

    public async Task<IEnumerable<MachineBanknoteDto>> GetAllAsync()
    {
        var elements = (await _unit.MachineBanknotes.GetAllAsync()).ToList();
        var mappedElements = _mapper.Map<IEnumerable<MachineBanknoteDto>>(elements);

        return mappedElements;
    }

    public async Task<MachineBanknoteDto> GetAsync(int id)
    {
        var element = await _unit.MachineBanknotes.GetAsync(id);
        var mappedElement = _mapper.Map<MachineBanknoteDto>(element);

        return mappedElement;
    }

    public async Task UpdateAsync(MachineBanknoteDto element)
    {
        var oldElement = await _unit.MachineBanknotes.GetAsync(element.Denomination);
        if (oldElement == null)
            throw new ObjectNotFoundException($"Банкнота с номиналом {element.Denomination} не найдена");

        _mapper.Map(element, oldElement);
        await _unit.MachineBanknotes.UpdateAsync(oldElement);
        await _unit.CommitAsync();
    }

    public async Task CleanAsync()
    {
        await _unit.MachineBanknotes.CleanAsync();
        await _unit.CommitAsync();
    }

    public async Task CreateRangeAsync(IEnumerable<MachineBanknoteDto> banknotes)
    {
        var mappedBanknotes = _mapper.Map<IEnumerable<MachineBanknote>>(banknotes);
        await _unit.MachineBanknotes.CreateRangeAsync(mappedBanknotes);

        await _unit.CommitAsync();
    }

    public async Task UpdateRangeAsync(IEnumerable<MachineBanknoteDto> banknotes)
    {
        var mappedBanknotes = _mapper.Map<IEnumerable<MachineBanknote>>(banknotes);
        await _unit.MachineBanknotes.UpdateRangeAsync(mappedBanknotes);

        await _unit.CommitAsync();
    }
}