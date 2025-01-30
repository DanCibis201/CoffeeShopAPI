using CoffeeShop.Application.Commands.CoffeeCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Proxy.Proxies;
using MediatR;

namespace CoffeeShop.Application.Handlers.CoffeeHandlers;

public class DeleteCoffeeByIdHandler : IRequestHandler<DeleteCoffeeByIdCommand, Unit>
{
    private readonly IProxy<Coffee> _proxy;

    public DeleteCoffeeByIdHandler(IProxy<Coffee> proxy)
    {
        _proxy = proxy;
    }

    public async Task<Unit> Handle(DeleteCoffeeByIdCommand request, CancellationToken cancellationToken)
    {
        await _proxy.SoftDeleteAsync(request.Id);
        return Unit.Value;
    }
}