using CoffeeShop.Infrastructure.Core.Enums;
using MediatR;
using System.Text.Json.Serialization;

namespace CoffeeShop.Application.Commands.OrderCommands;

public class UpdateOrderCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public Guid CoffeeId { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
    public OrderStatus Status { get; set; }

    [JsonConstructor]
    public UpdateOrderCommand(Guid id, Guid coffeeId,
        int quantity, DateTime orderDate, OrderStatus status)
    {
        Id = id;
        CoffeeId = coffeeId;
        Quantity = quantity;
        OrderDate = orderDate;
        Status = status;
    }
}