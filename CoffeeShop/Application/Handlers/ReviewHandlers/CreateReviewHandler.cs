using CoffeeShop.Application.Commands.ReviewCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Proxy.Proxies;
using MediatR;

namespace CoffeeShop.Application.Handlers.ReviewHandlers;

public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, Unit>
{
    private readonly IProxy<Review> _proxy;

    public CreateReviewHandler(IProxy<Review> proxy)
    {
        _proxy = proxy;
    }

    public async Task<Unit> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = new Review
        {
            Id = Guid.NewGuid(),
            CoffeeId = request.CoffeeId,
            UserName = request.UserName,
            Comment = request.Comment,
            Rating = request.Rating
        };

        await _proxy.AddAsync(review);
        return Unit.Value;
    }
}