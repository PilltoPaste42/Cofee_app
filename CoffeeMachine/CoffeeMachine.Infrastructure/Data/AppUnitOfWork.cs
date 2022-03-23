namespace CoffeeMachine.Infrastructure.UoW;

using CoffeeMachine.Core.Interfaces.Repositories;
using CoffeeMachine.Core.Interfaces.UoW;
using CoffeeMachine.Infrastructure.Data;
using CoffeeMachine.Infrastructure.Repositories;

/// <inheritdoc cref="IAppUnitOfWork"/>
public class AppUnitOfWork : IAppUnitOfWork
{
    private readonly AppDbContext _context;
    public ICoffeeRepository Coffee { get; }
    public IMachineBanknoteRepository MachineBanknotes { get; }
    public IOrderRepository Orders { get; }

    public AppUnitOfWork(AppDbContext context)
    {
        _context = context;
        Coffee = new CoffeeRepository(context);
        MachineBanknotes = new MachineBanknoteRepository(context);
        Orders = new OrderRepository(context);
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}