using CoffeeShop.Application.Queries.ReviewQueries;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Proxy.Proxies;
using MediatR;

namespace CoffeeShop.Application.Handlers.ReviewHandlers;

public class GetAllReviewsHandler : IRequestHandler<GetAllReviewsQuery, IEnumerable<Review>>
{
    private readonly IProxy<Review> _proxy;

    public GetAllReviewsHandler(IProxy<Review> proxy)
    {
        _proxy = proxy;
    }

    public async Task<IEnumerable<Review>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
    {
        return await _proxy.GetAllAsync();
    }
}