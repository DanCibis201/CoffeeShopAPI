using CoffeeShop.Database.SqlServer.Entities;

namespace CoffeeShop.Infrastructure.Observer;

public class LoggingService : IInventoryObserver
{
    public void Update(Order order)
    {
        Console.WriteLine($"Logging: Order {order.Id} has been updated.");
    }
}

public class UIUpdateService : IInventoryObserver
{
    public void Update(Order order)
    {
        Console.WriteLine($"UI update: Order {order.Id} has been updated.");
    }
}
