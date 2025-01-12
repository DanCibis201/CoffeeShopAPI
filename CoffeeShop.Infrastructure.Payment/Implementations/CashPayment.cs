using CoffeeShop.Infrastructure.Payment.Abstractions;

namespace CoffeeShop.Infrastructure.Payment.Implementations;

public class CashPayment : IPaymentMethod
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine("Cash payment successfully completed.");
    }
}
