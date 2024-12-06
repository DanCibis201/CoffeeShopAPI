using CoffeeShop.Application.Commands.CoffeeCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Proxy.Proxies;
using MediatR;

namespace CoffeeShop.Application.Handlers.CoffeeHandlers
{
    public class CreateCoffeeHandler : IRequestHandler<CreateCoffeeCommand, Unit>
    {
        private readonly IProxy<Coffee> _proxy;

        public CreateCoffeeHandler(IProxy<Coffee> proxy)
        {
            _proxy = proxy;
        }

        public async Task<Unit> Handle(CreateCoffeeCommand request, CancellationToken cancellationToken)
        {
            var coffee = new Coffee
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Intensity = request.Intensity,
                Type = request.Type,
                Brand = request.Brand
            };

            await _proxy.AddAsync(coffee);
            return Unit.Value;
        }
    }
}