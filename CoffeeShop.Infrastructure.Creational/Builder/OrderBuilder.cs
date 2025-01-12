using CoffeeShop.Database.SqlServer.Entities;
using Microsoft.Extensions.Logging;

namespace CoffeeShop.Infrastructure.Creational.Builder;

public class OrderBuilder
{
    private Order _order;
    private ILogger<OrderBuilder> _logger;

    public OrderBuilder(ILogger<OrderBuilder> logger)
    {
        _order = new Order();
        _logger = logger;
    }

    public OrderBuilder WithCoffeeId(Guid coffeeId)
    {
        _order.CoffeeId = coffeeId;
        return this;
    }

    public OrderBuilder WithQuantity(int quantity)
    {
        _order.Quantity = quantity;
        return this;
    }

    public OrderBuilder WithOrderDate(DateTime orderDate)
    {
        _order.OrderDate = orderDate;
        return this;
    }

    public Order Build()
    {
        // You can add any validation logic here
        if (_order.CoffeeId == Guid.Empty)
            throw new ArgumentException("CoffeeId must be specified.");

        if (_order.Quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        if (_order.OrderDate == default)
            throw new ArgumentException("OrderDate must be specified.");

        _logger.LogInformation("Order was successfully built.");
        return _order;
    }
}