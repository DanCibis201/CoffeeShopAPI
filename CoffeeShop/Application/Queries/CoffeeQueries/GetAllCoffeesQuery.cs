using MediatR;
using CoffeeShop.Database.SqlServer.Entities;

namespace CoffeeShop.Application.Queries.CoffeeQueries;

public class GetAllCoffeesQuery : IRequest<IEnumerable<Coffee>>
{
}