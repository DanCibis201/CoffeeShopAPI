namespace CoffeeShop.Database.SqlServer.Entities;

public class Order
{
    public Guid Id { get; set; }
    public Guid CoffeeId { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }

    public Coffee? Coffee { get; set; }
}