using CoffeeShop.Application.Commands.SubscriptionCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Proxy.Proxies;
using MediatR;

namespace CoffeeShop.Application.Handlers.SubscriptionHandlers;

public class DeleteSubscriptionByIdHandler : IRequestHandler<DeleteSubscriptionByIdCommand, Unit>
{
    private readonly IProxy<Subscription> _proxy;

    public DeleteSubscriptionByIdHandler(IProxy<Subscription> proxy)
    {
        _proxy = proxy;
    }

    public async Task<Unit> Handle(DeleteSubscriptionByIdCommand request, CancellationToken cancellationToken)
    {
        await _proxy.SoftDeleteAsync(request.Id);
        return Unit.Value;
    }
}