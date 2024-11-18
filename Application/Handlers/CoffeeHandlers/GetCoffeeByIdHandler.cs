using CoffeeShop.Application.Queries.CoffeeQueries;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Repositories;
using MediatR;

namespace CoffeeShop.Application.Handlers.CoffeeHandlers;

public class GetCoffeeByIdHandler : IRequestHandler<GetCoffeeByIdQuery, Coffee>
{
    private readonly IRepository<Coffee> _repository;

    public GetCoffeeByIdHandler(IRepository<Coffee> repository)
    {
        _repository = repository;
    }

    public async Task<Coffee> Handle(GetCoffeeByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}