using CoffeeShop.Database.SqlServer.Entities;

namespace CoffeeShop.Infrastructure.Observer;

public interface IInventoryObserver
{
    void Update(Order product);
}
