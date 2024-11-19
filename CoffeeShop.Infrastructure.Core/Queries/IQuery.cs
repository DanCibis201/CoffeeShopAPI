using MediatR;

namespace CoffeeShop.Infrastructure.Core.Queries;

public interface IQuery<out TQueryResponse> : IRequest<TQueryResponse>
{
}