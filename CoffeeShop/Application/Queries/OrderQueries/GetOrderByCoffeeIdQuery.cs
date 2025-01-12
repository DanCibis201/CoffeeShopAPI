using CoffeeShop.Database.SqlServer.Entities;
using MediatR;

namespace CoffeeShop.Application.Queries.OrderQueries;

public record GetOrderByCoffeeIdQuery(Guid CoffeeId) : IRequest<Order?>;