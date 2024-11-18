using CoffeeShop.Application.Commands.ReviewCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Repositories;
using MediatR;

namespace CoffeeShop.Application.Handlers.ReviewHandlers;

public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, Unit>
{
    private readonly IRepository<Review> _repository;

    public CreateReviewHandler(IRepository<Review> repository)
    {
        _repository = repository;
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

        await _repository.AddAsync(review);
        return Unit.Value;
    }
}