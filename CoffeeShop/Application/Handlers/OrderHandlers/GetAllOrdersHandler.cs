using CoffeeShop.Application.Queries.OrderQueries;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Proxy.Proxies;
using MediatR;

namespace CoffeeShop.Application.Handlers.OrderHandlers;
public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
{
    private readonly IProxy<Order> _proxy;

    public GetAllOrdersHandler(IProxy<Order> proxy)
    {
        _proxy = proxy;
    }

    public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        return await _proxy.GetAllAsync();
    }
}