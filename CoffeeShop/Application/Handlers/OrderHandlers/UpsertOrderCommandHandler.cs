using CoffeeShop.Application.Commands.OrderCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Database.SqlServer.Repositories;
using MediatR;

namespace CoffeeShop.Application.Handlers.OrderHandlers;

public class UpsertOrderCommandHandler : IRequestHandler<UpsertOrderCommand>
{
    private readonly OrderRepository _orderRepository;

    public UpsertOrderCommandHandler(OrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(UpsertOrderCommand request, CancellationToken cancellationToken)
    {
        var existingOrder = await _orderRepository.GetOrderByCoffeeIdAsync(request.CoffeeId);

        if (existingOrder != null)
        {
            existingOrder.Quantity += request.Quantity;
            existingOrder.OrderDate = request.OrderDate;
            await _orderRepository.UpdateAsync(existingOrder);
        }
        else
        {
            var newOrder = new Order
            {
                Id = Guid.NewGuid(),
                CoffeeId = request.CoffeeId,
                Quantity = request.Quantity,
                OrderDate = DateTime.Now
            };
            await _orderRepository.AddAsync(newOrder);
        }
    }
}