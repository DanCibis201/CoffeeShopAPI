using MediatR;

namespace CoffeeShop.Application.Commands.CoffeeCommands;

public class RestoreCoffeeByIdCommand : IRequest<Unit>
{
    public Guid Id { get; }

    public RestoreCoffeeByIdCommand(Guid id)
    {
        Id = id;
    }
}