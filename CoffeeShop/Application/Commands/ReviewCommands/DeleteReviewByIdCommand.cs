using MediatR;

namespace CoffeeShop.Application.Commands.ReviewCommands;

public class DeleteReviewByIdCommand : IRequest<Unit>
{
    public Guid Id { get; set; }

    public DeleteReviewByIdCommand(Guid id)
    {
        Id = id;
    }
}