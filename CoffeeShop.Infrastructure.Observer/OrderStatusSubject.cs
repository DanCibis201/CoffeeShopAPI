using CoffeeShop.Database.SqlServer.Entities;

namespace CoffeeShop.Infrastructure.Observer;

public class OrderStatusSubject : IInventorySubject
{
    private List<IInventoryObserver> _observers = new List<IInventoryObserver>();
    private Order _order;

    public void Attach(IInventoryObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IInventoryObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_order);
        }
    }

    public void UpdateOrderStatus(Order order)
    {
        _order = order;
        Notify();
    }
}