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
            .ForMember(s => s.Id, param => param.Ignore())
            .ReverseMap();
        CreateMap<MachineBanknoteDto, MachineBanknote>()
            .ReverseMap(); 
        CreateMap<OrderDto, Order>()
            .ForMember(s => s.Id, param => param.Ignore())
            .ReverseMap();
    }
}