using CoffeeShop.Database.SqlServer.Entities;

namespace CoffeeShop.Infrastructure.CoR.Handlers;

public abstract class OrderHandler : IOrderHandler
{
    private IOrderHandler _nextHandler;

    public IOrderHandler SetNext(IOrderHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public virtual void Handle(Order order)
    {
        _nextHandler?.Handle(order);
    }
}
