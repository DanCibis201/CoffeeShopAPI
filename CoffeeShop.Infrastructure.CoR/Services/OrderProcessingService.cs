using CoffeeShop.Database.SqlServer.Entities;

namespace CoffeeShop.Infrastructure.CoR.Services;

public class OrderProcessingService
{
    private readonly IOrderHandler _orderHandler;

    public OrderProcessingService(IOrderHandler orderHandler)
    {
        _orderHandler = orderHandler;
    }

    public void ProcessOrder(Order order)
    {
        _orderHandler.Handle(order);
    }
}