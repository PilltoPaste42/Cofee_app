namespace CoffeeMachine.Infrastructure.Services;

using CoffeeMachine.Core.Dto;
using CoffeeMachine.Core.Exceptions;
using CoffeeMachine.Core.Interfaces.Services;
using CoffeeMachine.Core.Interfaces.UoW;
using CoffeeMachine.Core.Models;

using global::AutoMapper;

/// <summary>
///     Сервис для работы с кофе
/// </summary>
/// <inheritdoc cref="ICoffeeService"/>
public class CoffeeService : ICoffeeService
{
    private readonly IMapper _mapper;
    private readonly IAppUnitOfWork _unit;

    public CoffeeService(IAppUnitOfWork unit, IMapper mapper)
    {
        _mapper = mapper;
        _unit = unit;
    }

    public async Task CreateAsync(CoffeeDto element)
    {
        var mappedElement = _mapper.Map<Coffee>(element);
        await _unit.Coffee.CreateAsync(mappedElement);

        await _unit.CommitAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unit.Coffee.DeleteAsync(id);
        await _unit.CommitAsync();
    }

    public async Task<IEnumerable<CoffeeDto>> GetAllAsync()
    {
        var elements = (await _unit.Coffee.GetAllAsync()).ToList();
        var mappedElements = _mapper.Map<IEnumerable<CoffeeDto>>(elements);

        return mappedElements;
    }

    public async Task<CoffeeDto> GetAsync(int id)
    {
        var element = await _unit.Coffee.GetAsync(id);
        if (element == null)
            throw new ObjectNotFoundException($"Кофе с номером {id} не найден");
        var mappedElement = _mapper.Map<CoffeeDto>(element);

        return mappedElement;
    }

    public async Task UpdateAsync(CoffeeDto element)
    {
        var oldElement = await _unit.Coffee.GetAsync(element.Id);
        if (oldElement == null)
            throw new ObjectNotFoundException($"Кофе с номером {element.Id} не найден");

        _mapper.Map(element, oldElement);
        await _unit.Coffee.UpdateAsync(oldElement);
        await _unit.CommitAsync();
    }
}