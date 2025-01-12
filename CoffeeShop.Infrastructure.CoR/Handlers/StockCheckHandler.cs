using CoffeeShop.Database.SqlServer.Entities;

namespace CoffeeShop.Infrastructure.CoR.Handlers;

public class StockCheckHandler : OrderHandler
{
    public override void Handle(Order order)
    {
        Console.WriteLine("Stock checked");
        base.Handle(order);
    }
}

public class OrderPlacementHandler : OrderHandler
{
    public override void Handle(Order order)
    {
        Console.WriteLine("Order placed");
        base.Handle(order);
    }
}

public class PaymentHandler : OrderHandler
{
    public override void Handle(Order order)
    {
        Console.WriteLine("Waiting payment");
        base.Handle(order);
    }
}
