namespace CoffeeShop.Infrastructure.Core.EventSourcing;

public interface IEventHandler<in T> where T : IEvent
{
    Task HandleAsync(T @event);
}