using CoffeeShop.Infrastructure.Core.Enums;
using MediatR;

namespace CoffeeShop.Application.Commands.CoffeeCommands;

public class UpdateCoffeeCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public int? Intensity { get; set; }
    public string? ImageUrl { get; set; }
    public CoffeeType? Type { get; set; }
    public CoffeeBrand? Brand { get; set; }

    public UpdateCoffeeCommand(Guid id, string name, 
        decimal price, string description, 
        string imageUrl, int intensity,
        CoffeeType type, CoffeeBrand brand)
    {
        Id = id;
        Name = name;
        Price = price;
        Description = description;
        ImageUrl = imageUrl;
        Intensity = intensity;
        Type = type;
        Brand = brand;
    }
}