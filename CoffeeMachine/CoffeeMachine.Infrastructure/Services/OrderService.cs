namespace CoffeeMachine.Infrastructure.Services;

using System.ComponentModel.DataAnnotations;

using CoffeeMachine.Core.Dto;
using CoffeeMachine.Core.Exceptions;
using CoffeeMachine.Core.Interfaces.Services;
using CoffeeMachine.Core.Interfaces.UoW;
using CoffeeMachine.Core.Models;

using global::AutoMapper;

using Microsoft.EntityFrameworkCore;

///<inheritdoc cref="IOrderService"/>
public class OrderService : IOrderService
{
    private readonly IMapper _mapper;
    private readonly IAppUnitOfWork _unit;

    public OrderService(IAppUnitOfWork unit, IMapper mapper)
    {
        _mapper = mapper;
        _unit = unit;
    }

    public async Task<IEnumerable<MachineBanknoteDto>> CreateOrderAsync(OrderCreateDto orderCreateDto)
    {
        var order = new Order
        {
            Date = DateTime.Now.ToUniversalTime()
        };

        var coffeeQuery = await _unit.Coffee.GetAllAsync();
        var coffeeInOrderIdList = orderCreateDto.CoffeeList.Select(orderCoffeeDto => orderCoffeeDto.Coffee.Id).ToList();
        var coffeeInOrderNotExistIdList = coffeeInOrderIdList.Where(x => !coffeeQuery.Any(coffee => coffee.Id == x)).ToList();
        var duplicateCoffeeInOrderIdList =
            coffeeInOrderIdList.GroupBy(v => v).Where(g => g.Count() > 1).Select(g => g.Key).ToList();

        if (coffeeInOrderIdList.Count == 0)
            throw new ObjectNotFoundException("Ошибка при добавлении кофе в заказ. Кофе в заказе не найден");

        if (coffeeInOrderNotExistIdList.Count > 0)
        {
            var coffeeNotExistIdString = string.Join(", ", coffeeInOrderNotExistIdList);
            throw new ObjectNotFoundException("Ошибка при добавлении кофе в заказ. " +
                                              $"Кофе с идентификатором(и) {coffeeNotExistIdString} не найдены");
        }

        if (duplicateCoffeeInOrderIdList.Count > 0)
        {
            var duplicateCoffeeInOrderIdString = string.Join(", ", duplicateCoffeeInOrderIdList);
            throw new ValidationException("Ошибка при добавлении кофе в заказ. " +
                                          $"Кофе с идентификатором {duplicateCoffeeInOrderIdString} дублируются");
        }

        order.OrderCoffee = coffeeQuery
            .Where(coffee => coffeeInOrderIdList.Contains(coffee.Id))
                .ToList()
            .Select(coffee => new OrderCoffee
            {
                Order = order,
                Coffee = coffee,
                Count = orderCreateDto.CoffeeList.Single(orderCoffeeDto => orderCoffeeDto.Coffee.Id == coffee.Id).Count
            })
            .ToList();

        foreach (var orderCoffee in order.OrderCoffee)
        {
            order.TotalCost += orderCoffee.Count * (int) orderCoffee.Coffee.Price;
        }

        var balance = await InsertBanknotesAsync(orderCreateDto.Banknotes);

        var change = balance - order.TotalCost;
        var changeInBanknotes = await GetChangeInBanknotes(change);

        await _unit.Orders.CreateAsync(order);
        await _unit.CommitAsync();

        return changeInBanknotes;
    }

    /// <summary>
    ///     Получение всех заказов 
    /// </summary>
    public async Task<IEnumerable<OrderReadDto>> GetOrdersAsync()
    {
        var orders = (await _unit.Orders.GetAllAsync())
            .Include(order => order.OrderCoffee)
            .ThenInclude(orderCoffee => orderCoffee.Coffee)
            .ToList();
        var mappedOrders = _mapper.Map<IEnumerable<OrderReadDto>>(orders);

        return mappedOrders;
    }

    /// <summary>
    ///     Выдача сдачи в банкнотах
    /// </summary>
    /// <param name="change"> Значение сдачи </param>
    /// <returns> Список банкнот сдачи </returns>
    /// <exception cref="ValidationException"> Исключение для некорректного значения сдачи </exception>
    private async Task<IEnumerable<MachineBanknoteDto>> GetChangeInBanknotes(int change)
    {
        if (change < 0)
            throw new ValidationException("Ошибка при создании заказа. Недостаточно средств");

        var result = new List<MachineBanknoteDto>();

        var machineBanknotesList = (await _unit.MachineBanknotes.GetAllAsync())
            .OrderByDescending(machineBanknote => machineBanknote.Denomination).ToList();

        foreach (var banknote in machineBanknotesList)
        {
            if (change == 0)
                break;

            var removeCount = change / banknote.Denomination;
            if (removeCount == 0 || banknote.Count == 0)
                continue;
            if (removeCount > banknote.Count)
                removeCount = banknote.Count;

            result.Add(new MachineBanknoteDto
            {
                Count = removeCount,
                Denomination = banknote.Denomination
            });
            banknote.Count -= removeCount;
            change -= removeCount * banknote.Denomination;
        }

        if (change > 0)
            throw new ValidationException("Ошибка при создании заказа. Автомат не может выдать сдачу!");

        await _unit.MachineBanknotes.UpdateRangeAsync(machineBanknotesList);

        return result;
    }

    /// <summary>
    ///     Внесение банкнот в автомат
    /// </summary>
    /// <param name="insertBanknotesDto"> Список DTO вносимых банкнот </param>
    /// <returns> Значение суммы всех внесенных банкнот </returns>
    /// <exception cref="ValidationException"> Исключение для не поддерживаемых банкнот </exception>
    private async Task<int> InsertBanknotesAsync(IEnumerable<MachineBanknoteDto> insertBanknotesDto)
    {
        var balance = 0;

        var machineBanknotesQuery = await _unit.MachineBanknotes.GetAllAsync();
        var banknoteDenominationsList = machineBanknotesQuery.Select(machineBanknote => machineBanknote.Denomination).ToList();

        var notSupportBanknotesDenominationList = insertBanknotesDto
            .Where(banknoteDto => !banknoteDenominationsList.Contains(banknoteDto.Denomination))
            .Select(banknoteDto => banknoteDto.Denomination);

        if (notSupportBanknotesDenominationList.Any())
        {
            var notSupportBanknotesString = string.Join(", ", notSupportBanknotesDenominationList);
            throw new ValidationException(
                $"Ошибка при создании заказа. Банкноты с номиналом {notSupportBanknotesString} не поддерживаются");
        }

        var insertBanknotesList =
            machineBanknotesQuery.Where(machineBanknote => banknoteDenominationsList.Contains(machineBanknote.Denomination)).ToList();


        foreach (var banknote in insertBanknotesDto)
        {
            if (banknote.Count < 0)
                throw new ValidationException(
                    $"Ошибка при создании заказа. У банкноты с номиналом {banknote.Denomination} отрицательное количество");

            var machineBanknote = insertBanknotesList.Single(x => x.Denomination == banknote.Denomination);
            machineBanknote.Count += banknote.Count;

            balance += banknote.Denomination * banknote.Count;
        }

        await _unit.MachineBanknotes.UpdateRangeAsync(insertBanknotesList);

        return balance;
    }
}