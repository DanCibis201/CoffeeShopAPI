using CoffeeShop.Application.Queries.CoffeeQueries;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Proxy.Proxies;
using MediatR;

namespace CoffeeShop.Application.Handlers.CoffeeHandlers;

public class GetCoffeeByIdHandler : IRequestHandler<GetCoffeeByIdQuery, Coffee>
{
    private readonly IProxy<Coffee> _proxy;

    public GetCoffeeByIdHandler(IProxy<Coffee> proxy)
    {
        _proxy = proxy;
    }

    public async Task<Coffee> Handle(GetCoffeeByIdQuery request, CancellationToken cancellationToken)
    {
        return await _proxy.GetByIdAsync(request.Id);
    }
}