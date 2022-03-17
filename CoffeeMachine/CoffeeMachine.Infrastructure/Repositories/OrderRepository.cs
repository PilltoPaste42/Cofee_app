namespace CoffeeMachine.Infrastructure.Repositories;

using CoffeeMachine.Core.Interfaces.Repositories;
using CoffeeMachine.Core.Models;
using CoffeeMachine.Infrastructure.Data;

/// <inheritdoc cref="IOrderRepository"/>
public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }
}