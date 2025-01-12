using CoffeeShop.Infrastructure.Observer;

public interface IInventorySubject
{
    void Attach(IInventoryObserver observer);
    void Detach(IInventoryObserver observer);
    void Notify();
}