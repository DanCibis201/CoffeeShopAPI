using MediatR;

namespace CoffeeShop.Application.Commands.SubscriptionCommands;

public class RestoreSubscriptionByIdCommand : IRequest<Unit>
{
    public Guid Id { get; }

    public RestoreSubscriptionByIdCommand(Guid id)
    {
        Id = id;
    }
}