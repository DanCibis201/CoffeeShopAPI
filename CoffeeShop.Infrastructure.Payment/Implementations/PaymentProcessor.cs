using CoffeeShop.Infrastructure.Payment.Abstractions;

namespace CoffeeShop.Infrastructure.Payment.Implementations;

public class PaymentProcessor : PaymentSystem
{
    public PaymentProcessor(IPaymentMethod paymentMethod) : base(paymentMethod) { }

    public override void MakePayment(decimal amount)
    {
        PaymentMethod.ProcessPayment(amount);
    }
}