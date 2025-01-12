using CoffeeShop.Database.SqlServer.Entities;

namespace CoffeeShop.Infrastructure.Creational.FactoryMethod
{
    public class CoffeeHandler
    {
        public FastCoffee CreateCoffeeOrder(string coffeeType)
        {
            var coffee = CoffeeFactory.CreateCoffee(coffeeType);
            Console.WriteLine($"Created {coffee.Name} - {coffee.Description} for ${coffee.Price}");
            return coffee;
        }
    }
}
