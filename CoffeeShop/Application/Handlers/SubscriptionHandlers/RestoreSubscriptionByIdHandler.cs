using CoffeeShop.Application.Commands.SubscriptionCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Proxy.Proxies;
using MediatR;

namespace CoffeeShop.Application.Handlers.SubscriptionHandlers;

public class RestoreSubscriptionByIdHandler : IRequestHandler<RestoreSubscriptionByIdCommand, Unit>
{
    private readonly IProxy<Subscription> _proxy;

    public RestoreSubscriptionByIdHandler(IProxy<Subscription> proxy)
    {
        _proxy = proxy;
    }

    public async Task<Unit> Handle(RestoreSubscriptionByIdCommand request, CancellationToken cancellationToken)
    {
        await _proxy.RestoreAsync(request.Id);
        return Unit.Value;
    }
}