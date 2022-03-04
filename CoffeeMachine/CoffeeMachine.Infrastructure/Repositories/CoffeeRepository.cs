namespace CoffeeMachine.Infrastructure.Repositories;

using CoffeeMachine.Core.Interfaces.Repositories;
using CoffeeMachine.Core.Models;
using CoffeeMachine.Infrastructure.Data;

/// <inheritdoc cref="ICoffeeRepository"/>
public class CoffeeRepository : BaseRepository<Coffee>, ICoffeeRepository
{
    public CoffeeRepository(AppDbContext context) : base(context)
    {
    }
}