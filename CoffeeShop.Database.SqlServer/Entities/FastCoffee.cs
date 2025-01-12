namespace CoffeeShop.Database.SqlServer.Entities
{
    public abstract class FastCoffee
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
