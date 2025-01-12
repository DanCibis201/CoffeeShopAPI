using CoffeeShop.Application.Queries.ReviewQueries;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Proxy.Proxies;
using MediatR;

namespace CoffeeShop.Application.Handlers.ReviewHandlers;

public class GetReviewByIdHandler : IRequestHandler<GetReviewByIdQuery, Review>
{
    private readonly IProxy<Review> _proxy;

    public GetReviewByIdHandler(IProxy<Review> proxy)
    {
        _proxy = proxy;
    }

    public async Task<Review> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
    {
        return await _proxy.GetByIdAsync(request.Id);
    }
}