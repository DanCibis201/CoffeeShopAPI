using CoffeeShop.Application.Commands.OrderCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Proxy.Proxies;
using MediatR;

namespace CoffeeShop.Application.Handlers.OrderHandlers;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Unit>
{
    private readonly IProxy<Order> _proxy;

    public CreateOrderHandler(IProxy<Order> proxy)
    {
        _proxy = proxy;
    }

    public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            CoffeeId = request.CoffeeId,
            Quantity = request.Quantity,
            OrderDate = DateTime.UtcNow
        };
        await _proxy.AddAsync(order);
        return Unit.Value;
    }
}