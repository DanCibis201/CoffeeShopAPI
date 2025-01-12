namespace CoffeeShop.Database.SqlServer.Entities
{
    public class Espresso : FastCoffee
    {
        public Espresso()
        {
            Name = "Espresso";
            Price = 2.5m;
            Description = "Strong, black coffee brewed by forcing steam through ground coffee beans.";
        }
    }

    public class Latte : FastCoffee
    {
        public Latte()
        {
            Name = "Latte";
            Price = 4.0m;
            Description = "Coffee made with espresso and steamed milk.";
        }
    }
}