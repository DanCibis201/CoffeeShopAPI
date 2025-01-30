using CoffeeShop.Application.Queries.SubscriptionQueries;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Proxy.Proxies;
using MediatR;

namespace CoffeeShop.Application.Handlers.SubscriptionHandlers;

public class GetAllSubscriptionsHandler : IRequestHandler<GetAllSubscriptionsQuery, IEnumerable<Subscription>>
{
    private readonly IProxy<Subscription> _proxy;

    public GetAllSubscriptionsHandler(IProxy<Subscription> proxy)
    {
        _proxy = proxy;
    }
    public async Task<IEnumerable<Subscription>> Handle(GetAllSubscriptionsQuery request, CancellationToken cancellationToken)
    {
        return await _proxy.GetAllAsync();
    }
}