namespace CoffeeShop.Infrastructure.Payment.Abstractions;

public interface IPaymentMethod
{
    void ProcessPayment(decimal amount);
}
