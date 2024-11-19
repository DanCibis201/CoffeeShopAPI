using CoffeeShop.Infrastructure.Core.Enums;
using MediatR;

namespace CoffeeShop.Application.Commands.CoffeeCommands;

public class CreateCoffeeCommand : IRequest<Unit>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public int? Intensity { get; set; }
    public string? ImageUrl { get; set; }
    public CoffeeType? Type { get; set; }
    public CoffeeBrand? Brand { get; set; }
}