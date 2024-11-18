using CoffeeShop.Application.Commands.OrderCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Repositories;
using MediatR;

namespace CoffeeShop.Application.Handlers.OrderHandlers;

public class DeleteOrderByIdHandler : IRequestHandler<DeleteOrderByIdCommand, Unit>
{
    private readonly IRepository<Order> _repository;

    public DeleteOrderByIdHandler(IRepository<Order> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteOrderByIdCommand command, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(command.Id);
        return Unit.Value;
    }
}