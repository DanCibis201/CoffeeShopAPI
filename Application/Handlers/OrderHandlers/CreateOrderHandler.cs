using CoffeeShop.Application.Commands.OrderCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Repositories;
using MediatR;

namespace CoffeeShop.Application.Handlers.OrderHandlers;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Unit>
{
    private readonly IRepository<Order> _repository;

    public CreateOrderHandler(IRepository<Order> repository)
    { 
        _repository = repository;
    }

    public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken) 
    { 
        var order = new Order 
        { 
            Id = Guid.NewGuid(), 
            CoffeeId = request.CoffeeId, 
            Quantity = request.Quantity, 
            OrderDate = DateTime.UtcNow 
        }; 
        await _repository.AddAsync(order);
        return Unit.Value; 
    }
}