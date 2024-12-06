using CoffeeShop.Application.Queries.OrderQueries;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Proxy.Proxies;
using MediatR;

namespace CoffeeShop.Application.Handlers.OrderHandlers;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Order>
{
    private readonly IProxy<Order> _proxy;

    public GetOrderByIdHandler(IProxy<Order> proxy)
    {
        _proxy = proxy;
    }

    public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        return await _proxy.GetByIdAsync(request.Id);
    }
}