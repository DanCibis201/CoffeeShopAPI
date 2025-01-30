using CoffeeShop.Database.SqlServer.Entities.Interfaces;

namespace CoffeeShop.Database.SqlServer.Entities;

public class Subscription : ISoftDeletable
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public string Benefits { get; set; }
    public bool IsDeleted { get; set; }
}