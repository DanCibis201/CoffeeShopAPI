using MediatR;

namespace CoffeeShop.Application.Commands.SubscriptionCommands;

public class UpsertSubscriptionCommand : IRequest
{
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public string Benefits { get; set; }
}