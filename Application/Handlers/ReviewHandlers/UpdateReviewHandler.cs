using CoffeeShop.Application.Commands.ReviewCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Repositories;
using MediatR;

namespace CoffeeShop.Application.Handlers.ReviewHandlers;

public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand, Unit>
{
    private readonly IRepository<Review> _repository;

    public UpdateReviewHandler(IRepository<Review> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await _repository.GetByIdAsync(request.Id);
        if (review == null)
        {
            throw new KeyNotFoundException("Review not found");
        }

        review.CoffeeId = request.CoffeeId;
        review.UserName = request.UserName;
        review.Comment = request.Comment;
        review.Rating = request.Rating;

        await _repository.UpdateAsync(review);
        return Unit.Value;
    }
}