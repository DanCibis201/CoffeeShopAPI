using CoffeeShop.Database.SqlServer.Entities;
using MediatR;

namespace CoffeeShop.Application.Queries.ReviewQueries;

public record GetUserReviewByCoffeIdQuery(Guid CoffeeId, string UserName) : IRequest<Review?>;