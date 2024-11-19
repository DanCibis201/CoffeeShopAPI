using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Core.Queries;

namespace CoffeeShop.Application.Queries.CoffeeQueries;

public class GetCoffeeByIdQuery : IQuery<Coffee>
{
    public Guid Id { get; set; }

    public GetCoffeeByIdQuery(Guid id)
    {
        Id = id;
    }
}