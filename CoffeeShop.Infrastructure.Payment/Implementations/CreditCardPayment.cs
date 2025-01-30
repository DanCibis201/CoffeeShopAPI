using CoffeeShop.Infrastructure.Payment.Abstractions;
using System;

namespace CoffeeShop.Infrastructure.Payment.Implementations;

public class CreditCardPayment : IPaymentMethod
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Credit card payment successfully completed: {amount}.");
    }
}
