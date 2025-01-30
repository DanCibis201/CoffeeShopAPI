namespace CoffeeShop.Database.SqlServer.Entities.Interfaces;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
}