using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Core.Queries;

namespace CoffeeShop.Application.Queries.OrderQueries;

public class GetOrderByIdQuery : IQuery<Order>
{
    public Guid Id { get; set; }

    public GetOrderByIdQuery(Guid id)
    {
        Id = id;
    }
}