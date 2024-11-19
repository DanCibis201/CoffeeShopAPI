using CoffeeShop.Application.Commands.ReviewCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Repositories;
using MediatR;

namespace CoffeeShop.Application.Handlers.ReviewHandlers;

public class DeleteReviewByIdHandler : IRequestHandler<DeleteReviewByIdCommand, Unit>
{
    private readonly IRepository<Review> _repository;

    public DeleteReviewByIdHandler(IRepository<Review> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteReviewByIdCommand command, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(command.Id);
        return Unit.Value;
    }
}