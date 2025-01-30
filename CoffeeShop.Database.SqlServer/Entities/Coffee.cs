using CoffeeShop.Database.SqlServer.Entities.Interfaces;
using CoffeeShop.Infrastructure.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Database.SqlServer.Entities;

public class Coffee : ISoftDeletable
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    [Range(1, 10, ErrorMessage = "Intensity must be between 1 and 10")]
    public int? Intensity { get; set; } = null;
    public string? ImageUrl { get; set; }
    public CoffeeType? Type { get; set; }
    public CoffeeBrand? Brand { get; set; }
    public bool IsDeleted { get; set; }

    public ICollection<Review>? Reviews { get; set; }
    public ICollection<Order>? Orders { get; set; }
}