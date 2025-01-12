using CoffeeShop.Database.SqlServer.Entities;

namespace CoffeeShop.Infrastructure.Creational.FactoryMethod
{
    public static class CoffeeFactory
    {
        public static FastCoffee CreateCoffee(string coffeeType)
        {
            return coffeeType.ToLower() switch
            {
                "espresso" => new Espresso(),
                "latte" => new Latte(),
                _ => throw new ArgumentException("Invalid coffee type")
            };
        }
    }
}
