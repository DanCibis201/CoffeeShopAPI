using CoffeeShop.Application.Commands.OrderCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Repositories;
using MediatR;

namespace CoffeeShop.Application.Handlers.OrderHandlers;

public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, Unit>
{
    private readonly IRepository<Order> _repository;

    public UpdateOrderHandler(IRepository<Order> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetByIdAsync(request.Id);
        if (order == null)
        {
            throw new KeyNotFoundException("Order not found");
        }

        order.CoffeeId = request.CoffeeId;
        order.Quantity = request.Quantity;
        order.OrderDate = request.OrderDate;

        await _repository.UpdateAsync(order);
        return Unit.Value;
    }
}