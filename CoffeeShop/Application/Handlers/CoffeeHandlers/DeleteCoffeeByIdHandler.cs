using CoffeeShop.Application.Commands.CoffeeCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Repositories;
using MediatR;

namespace CoffeeShop.Application.Handlers.CoffeeHandlers;

public class DeleteCoffeeByIdHandler : IRequestHandler<DeleteCoffeeByIdCommand, Unit>
{
    private readonly IRepository<Coffee> _repository;

    public DeleteCoffeeByIdHandler(IRepository<Coffee> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteCoffeeByIdCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}