using CoffeeShop.Application.Commands.SubscriptionCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Proxy.Proxies;
using MediatR;

namespace CoffeeShop.Application.Handlers.SubscriptionHandlers;

public class UpdateSubscriptionHandler : IRequestHandler<UpdateSubscriptionCommand, Unit>
{
    private readonly IProxy<Subscription> _proxy;

    public UpdateSubscriptionHandler(IProxy<Subscription> proxy)
    {
        _proxy = proxy;
    }

    public async Task<Unit> Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = await _proxy.GetByIdAsync(request.Id);
        if (subscription == null)
        {
            throw new KeyNotFoundException("Subscription not found");
        }

        subscription.Name = request.Name;
        subscription.Cost = request.Cost;
        subscription.Benefits = request.Benefits;
        subscription.IsDeleted = request.IsDeleted;

        await _proxy.UpdateAsync(subscription);
        return Unit.Value;
    }
}