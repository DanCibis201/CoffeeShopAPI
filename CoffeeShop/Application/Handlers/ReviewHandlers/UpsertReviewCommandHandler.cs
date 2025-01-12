using CoffeeShop.Application.Commands.ReviewCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Database.SqlServer.Repositories;
using MediatR;

namespace CoffeeShop.Application.Handlers.ReviewHandlers;

public class UpsertReviewCommandHandler : IRequestHandler<UpsertReviewCommand>
{
    private readonly ReviewRepository _reviewRepository;

    public UpsertReviewCommandHandler(ReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task Handle(UpsertReviewCommand request, CancellationToken cancellationToken)
    {
        var existingReview = await _reviewRepository.GetUserReviewByCoffeeIdAsync(request.CoffeeId, request.UserName);

        if (existingReview != null)
        {
            existingReview.Comment = request.Comment;
            existingReview.Rating = request.Rating;
            await _reviewRepository.UpdateAsync(existingReview);
        }
        else
        {
            var newReview = new Review
            {
                Id = Guid.NewGuid(),
                CoffeeId = request.CoffeeId,
                UserName = request.UserName,
                Comment = request.Comment,
                Rating = request.Rating
            };
            await _reviewRepository.AddAsync(newReview);
        }
    }
}