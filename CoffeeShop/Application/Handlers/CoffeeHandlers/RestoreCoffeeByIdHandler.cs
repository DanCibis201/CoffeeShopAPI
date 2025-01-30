using CoffeeShop.Application.Commands.CoffeeCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Proxy.Proxies;
using MediatR;

namespace CoffeeShop.Application.Handlers.CoffeeHandlers
{
    public class RestoreCoffeeByIdHandler : IRequestHandler<RestoreCoffeeByIdCommand, Unit>
    {
        private readonly IProxy<Coffee> _proxy;

        public RestoreCoffeeByIdHandler(IProxy<Coffee> proxy)
        {
            _proxy = proxy;
        }

        public async Task<Unit> Handle(RestoreCoffeeByIdCommand request, CancellationToken cancellationToken)
        {
            await _proxy.RestoreAsync(request.Id);
            return Unit.Value;
        }
    }
}