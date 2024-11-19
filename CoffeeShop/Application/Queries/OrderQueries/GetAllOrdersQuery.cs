using CoffeeShop.Database.SqlServer.Entities;
using MediatR;

namespace CoffeeShop.Application.Queries.OrderQueries;

public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
{
}