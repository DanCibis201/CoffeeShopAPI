using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Core.Queries;

namespace CoffeeShop.Application.Queries.SubscriptionQueries;

public class GetSubscriptionByIdQuery : IQuery<Subscription>
{
    public Guid Id { get; set; }

    public GetSubscriptionByIdQuery(Guid id)
    {
        Id = id;
    }
}