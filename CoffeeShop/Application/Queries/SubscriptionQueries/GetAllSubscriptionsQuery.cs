using CoffeeShop.Database.SqlServer.Entities;
using MediatR;

namespace CoffeeShop.Application.Queries.SubscriptionQueries
{
    public class GetAllSubscriptionsQuery : IRequest<IEnumerable<Subscription>>
    {
    }
}
