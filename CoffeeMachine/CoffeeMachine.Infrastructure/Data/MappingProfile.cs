namespace CoffeeMachine.Infrastructure.AutoMapper;

using CoffeeMachine.Core.Dto;
using CoffeeMachine.Core.Models;

using global::AutoMapper;

/// <summary>
///     Настройка маппинга 
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CoffeeDto, Coffee>()
            .ForMember(coffee => coffee.Id, expression => expression.Ignore())
            .ReverseMap();
        CreateMap<MachineBanknoteDto, MachineBanknote>()
            .ReverseMap();
        CreateMap<OrderCoffee, OrderCoffeeDto>()
            .ReverseMap();
        CreateMap<Order, OrderReadDto>()
            .ForMember(orderReadDto => orderReadDto.CoffeeList,
                expression => expression.MapFrom(order => order.OrderCoffee));
    }
}