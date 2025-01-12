using CoffeeShop.Application.Commands.OrderCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Database.SqlServer.Repositories;
using CoffeeShop.Infrastructure.Creational.Builder;
using MediatR;

namespace CoffeeShop.Application.Handlers.OrderHandlers;

public class UpsertOrderCommandHandler : IRequestHandler<UpsertOrderCommand, Order>
{
    private readonly OrderRepository _orderRepository;
    private readonly OrderBuilder _orderBuilder;

    public UpsertOrderCommandHandler(OrderRepository orderRepository, OrderBuilder orderBuilder)
    {
        _orderRepository = orderRepository;
        _orderBuilder = orderBuilder;
    }

    public async Task<Order> Handle(UpsertOrderCommand request, CancellationToken cancellationToken)
    {
        var existingOrder = await _orderRepository.GetOrderByCoffeeIdAsync(request.CoffeeId);

        if (existingOrder != null)
        {
            existingOrder.Quantity += request.Quantity;
            await _orderRepository.UpdateAsync(existingOrder);
            return existingOrder;
        }
        else
        {
            var newOrder = _orderBuilder
                .WithCoffeeId(request.CoffeeId)
                .WithQuantity(request.Quantity)
                .WithOrderDate(DateTime.UtcNow)
                .Build();

            await _orderRepository.AddAsync(newOrder);
            return newOrder;
        }
    }
}