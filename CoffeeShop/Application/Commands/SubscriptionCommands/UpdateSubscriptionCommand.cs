using MediatR;
using System.Text.Json.Serialization;

namespace CoffeeShop.Application.Commands.SubscriptionCommands;

public class UpdateSubscriptionCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public string Benefits { get; set; }
    public bool IsDeleted { get; set; }

    [JsonConstructor]
    public UpdateSubscriptionCommand(Guid id, string name, decimal cost, string benefits, bool isDeleted)
    {
        Id = id;
        Name = name;
        Cost = cost;
        Benefits = benefits;
        IsDeleted = isDeleted;
    }
}