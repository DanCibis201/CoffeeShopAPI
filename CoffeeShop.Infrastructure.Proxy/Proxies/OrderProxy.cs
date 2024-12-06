using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Database.SqlServer.Repositories;
using Microsoft.Extensions.Logging;

namespace CoffeeShop.Infrastructure.Proxy.Proxies;

public class OrderProxy : IProxy<Order>
{
    private readonly IRepository<Order> _repository;
    private readonly ILogger<OrderProxy> _logger;

    public OrderProxy(IRepository<Order> repository, ILogger<OrderProxy> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task AddAsync(Order order)
    {
        _logger.LogInformation($"Adding order for coffee with ID: {order.CoffeeId}");
        await _repository.AddAsync(order);
    }

    public async Task DeleteAsync(Guid id)
    {
        _logger.LogInformation($"Deleting order by ID: {id}");
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        _logger.LogInformation("Fetching all orders");
        return await _repository.GetAllAsync();
    }

    public async Task<Order> GetByIdAsync(Guid id)
    {
        _logger.LogInformation($"Fetching order by ID: {id}");
        return await _repository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Order order)
    {
        _logger.LogInformation($"Updating order: {order.Id}");
        await _repository.UpdateAsync(order);
    }
}