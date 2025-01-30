using CoffeeShop.Database.SqlServer.Entities;
using MediatR;

namespace CoffeeShop.Application.Queries.CoffeeQueries;

public class GetAllCoffeesQuery : IRequest<IEnumerable<Coffee>>
{
}