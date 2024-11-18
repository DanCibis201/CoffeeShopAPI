using CoffeeShop.Database.SqlServer.Entities;
using MediatR;

namespace CoffeeShop.Application.Queries.ReviewQueries;

public class GetAllReviewsQuery : IRequest<IEnumerable<Review>>
{
}