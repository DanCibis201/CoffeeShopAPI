using CoffeeShop.Application.Commands.ReviewCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Proxy.Proxies;
using MediatR;

namespace CoffeeShop.Application.Handlers.ReviewHandlers;

public class DeleteReviewByIdHandler : IRequestHandler<DeleteReviewByIdCommand, Unit>
{
    private readonly IProxy<Review> _proxy;

    public DeleteReviewByIdHandler(IProxy<Review> proxy)
    {
        _proxy = proxy;
    }

    public async Task<Unit> Handle(DeleteReviewByIdCommand command, CancellationToken cancellationToken)
    {
        await _proxy.DeleteAsync(command.Id);
        return Unit.Value;
    }
}