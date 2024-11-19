using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Core.Queries;

namespace CoffeeShop.Application.Queries.ReviewQueries;

public class GetReviewByIdQuery : IQuery<Review>
{
    public Guid Id { get; set; }

    public GetReviewByIdQuery(Guid id)
    {
        Id = id;
    }
}