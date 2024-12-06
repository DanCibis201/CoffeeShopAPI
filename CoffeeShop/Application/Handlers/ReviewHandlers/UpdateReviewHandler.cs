using CoffeeShop.Application.Commands.ReviewCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Proxy.Proxies;
using MediatR;

namespace CoffeeShop.Application.Handlers.ReviewHandlers;

public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand, Unit>
{
    private readonly IProxy<Review> _proxy;

    public UpdateReviewHandler(IProxy<Review> proxy)
    {
        _proxy = proxy;
    }

    public async Task<Unit> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await _proxy.GetByIdAsync(request.Id);
        if (review == null)
        {
            throw new KeyNotFoundException("Review not found");
        }

        review.CoffeeId = request.CoffeeId;
        review.UserName = request.UserName;
        review.Comment = request.Comment;
        review.Rating = request.Rating;

        await _proxy.UpdateAsync(review);
        return Unit.Value;
    }
}