using CoffeeShop.Application.Queries.ReviewQueries;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Database.SqlServer.Repositories;
using MediatR;

namespace CoffeeShop.Application.Handlers.ReviewHandlers;

public class GetReviewByUserIdQueryHandler : IRequestHandler<GetUserReviewByCoffeIdQuery, Review?>
{
    private readonly ReviewRepository _reviewRepository;

    public GetReviewByUserIdQueryHandler(ReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<Review?> Handle(GetUserReviewByCoffeIdQuery request, CancellationToken cancellationToken)
    {
        return await _reviewRepository.GetUserReviewByCoffeeIdAsync(request.CoffeeId, request.UserName);
    }
}