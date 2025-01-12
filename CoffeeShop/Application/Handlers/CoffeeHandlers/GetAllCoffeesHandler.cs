using CoffeeShop.Application.Queries.CoffeeQueries;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Proxy.Proxies;
using MediatR;

namespace CoffeeShop.Application.Handlers.CoffeeHandlers;

public class GetAllCoffeesHandler : IRequestHandler<GetAllCoffeesQuery, IEnumerable<Coffee>>
{
    private readonly IProxy<Coffee> _proxy;

    public GetAllCoffeesHandler(IProxy<Coffee> proxy)
    {
        _proxy = proxy;
    }

    public async Task<IEnumerable<Coffee>> Handle(GetAllCoffeesQuery request, CancellationToken cancellationToken)
    {
        return await _proxy.GetAllAsync();
    }
}