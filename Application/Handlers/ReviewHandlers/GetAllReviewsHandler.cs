using CoffeeShop.Application.Queries.ReviewQueries;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Repositories;
using MediatR;

namespace CoffeeShop.Application.Handlers.ReviewHandlers;

public class GetAllReviewsHandler : IRequestHandler<GetAllReviewsQuery, IEnumerable<Review>>
{
    private readonly IRepository<Review> _repository;

    public GetAllReviewsHandler(IRepository<Review> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Review>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}