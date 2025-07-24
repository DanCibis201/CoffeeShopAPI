using CoffeeShop.Application.Commands.OrderCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Proxy.Proxies;
using MediatR;

namespace CoffeeShop.Application.Handlers.OrderHandlers;

public class DeleteOrderByIdHandler(IProxy<Order> proxy) : IRequestHandler<DeleteOrderByIdCommand, Unit>
{
    private readonly IProxy<Order> _proxy = proxy;

    public async Task<Unit> Handle(DeleteOrderByIdCommand command, CancellationToken cancellationToken)
    {
        await _proxy.DeleteAsync(command.Id);
        return Unit.Value;
    }
}