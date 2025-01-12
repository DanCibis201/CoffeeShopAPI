using CoffeeShop.Database.SqlServer.Entities;

namespace CoffeeShop.Infrastructure.CoR;

public interface IOrderHandler
{
    IOrderHandler SetNext(IOrderHandler handler);
    void Handle(Order order);
}