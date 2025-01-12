using CoffeeShop.Application.Commands.OrderCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Proxy.Proxies;
using MediatR;

namespace CoffeeShop.Application.Handlers.OrderHandlers;

public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, Unit>
{
    private readonly IProxy<Order> _proxy;

    public UpdateOrderHandler(IProxy<Order> proxy)
    {
        _proxy = proxy;
    }

    public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _proxy.GetByIdAsync(request.Id);
        if (order == null)
        {
            throw new KeyNotFoundException("Order not found");
        }

        order.CoffeeId = request.CoffeeId;
        order.Quantity = request.Quantity;
        order.OrderDate = request.OrderDate;

        await _proxy.UpdateAsync(order);
        return Unit.Value;
    }
}