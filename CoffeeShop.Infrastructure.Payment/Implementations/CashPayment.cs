using CoffeeShop.Infrastructure.Payment.Abstractions;
using System;

namespace CoffeeShop.Infrastructure.Payment.Implementations;

public class CashPayment : IPaymentMethod
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Cash payment successfully completed: {amount}");
    }
}
