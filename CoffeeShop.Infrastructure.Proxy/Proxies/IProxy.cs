namespace CoffeeShop.Infrastructure.Proxy.Proxies;

public interface IProxy<T>
{
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T item);
    Task UpdateAsync(T item);
    Task DeleteAsync(Guid id);
}