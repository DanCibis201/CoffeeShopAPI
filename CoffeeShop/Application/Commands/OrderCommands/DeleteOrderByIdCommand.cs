using MediatR;

namespace CoffeeShop.Application.Commands.OrderCommands;

public class DeleteOrderByIdCommand : IRequest<Unit>
{
    public Guid Id { get; set; }

    public DeleteOrderByIdCommand(Guid id)
    {
        Id = id;
    }
}