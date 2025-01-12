using CoffeeShop.Application.Queries.OrderQueries;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Database.SqlServer.Repositories;
using MediatR;

namespace CoffeeShop.Application.Handlers.OrderHandlers;

public class GetOrderByCoffeeIdQueryHandler : IRequestHandler<GetOrderByCoffeeIdQuery, Order?>
{
    private readonly OrderRepository _orderRepository;

    public GetOrderByCoffeeIdQueryHandler(OrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order?> Handle(GetOrderByCoffeeIdQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetOrderByCoffeeIdAsync(request.CoffeeId);
    }
}