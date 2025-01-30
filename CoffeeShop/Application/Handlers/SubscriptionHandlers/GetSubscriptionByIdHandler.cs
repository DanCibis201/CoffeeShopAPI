using CoffeeShop.Application.Queries.SubscriptionQueries;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Proxy.Proxies;
using MediatR;

namespace CoffeeShop.Application.Handlers.SubscriptionHandlers;

public class GetSubscriptionByIdHandler : IRequestHandler<GetSubscriptionByIdQuery, Subscription>
{
    private readonly IProxy<Subscription> _proxy;

    public GetSubscriptionByIdHandler(IProxy<Subscription> proxy)
    {
        _proxy = proxy;
    }

    public async Task<Subscription> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
    {
        return await _proxy.GetByIdAsync(request.Id);
    }
}