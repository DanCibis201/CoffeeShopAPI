using MediatR;

namespace CoffeeShop.Application.Commands.SubscriptionCommands;

public class DeleteSubscriptionByIdCommand : IRequest<Unit>
{
    public Guid Id { get; set; }

    public DeleteSubscriptionByIdCommand(Guid id)
    {
        Id = id;
    }
}