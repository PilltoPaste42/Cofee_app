﻿namespace CoffeeMachine.Infrastructure.AutoMapper;

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
            .ForMember(m => m.Id, param => param.Ignore())
            .ReverseMap();
        CreateMap<MachineBanknoteDto, MachineBanknote>()
            .ReverseMap();
        CreateMap<OrderCoffee, OrderCoffeeDto>()
            .ReverseMap();
        CreateMap<Order, OrderReadDto>()
            .ForMember(x => x.CoffeeList, param => param.MapFrom(o => o.OrderCoffee));
    }
}