using MediatR;

namespace CoffeeShop.Application.Commands.CoffeeCommands;

public class DeleteCoffeeByIdCommand : IRequest<Unit>
{
    public Guid Id { get; set; }

    public DeleteCoffeeByIdCommand(Guid id)
    {
        Id = id;
    }
}