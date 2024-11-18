using CoffeeShop.Application.Queries.ReviewQueries;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Repositories;
using MediatR;

namespace CoffeeShop.Application.Handlers.ReviewHandlers;

public class GetReviewByIdHandler : IRequestHandler<GetReviewByIdQuery, Review>
{
    private readonly IRepository<Review> _repository;

    public GetReviewByIdHandler(IRepository<Review> repository)
    {
        _repository = repository;
    }

    public async Task<Review> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}