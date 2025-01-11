namespace CoffeeShop.Infrastructure.Payment.Abstractions;

public abstract class PaymentSystem
{
    protected IPaymentMethod PaymentMethod;

    protected PaymentSystem(IPaymentMethod paymentMethod)
    {
        PaymentMethod = paymentMethod;
    }

    public abstract void MakePayment(decimal amount);
}