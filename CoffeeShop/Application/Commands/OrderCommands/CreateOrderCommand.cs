using MediatR;

namespace CoffeeShop.Application.Commands.OrderCommands;

public class CreateOrderCommand : IRequest<Unit>
{
    public Guid CoffeeId { get; set; }
    public int Quantity { get; set; }
    public CreateOrderCommand(Guid coffeeId, int quantity)
    { 
        CoffeeId = coffeeId;
        Quantity = quantity;
    }
}