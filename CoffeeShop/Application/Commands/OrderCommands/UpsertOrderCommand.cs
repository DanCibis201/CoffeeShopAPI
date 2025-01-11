using MediatR;

namespace CoffeeShop.Application.Commands.OrderCommands;

public record UpsertOrderCommand(Guid CoffeeId, int Quantity) : IRequest<Unit>;