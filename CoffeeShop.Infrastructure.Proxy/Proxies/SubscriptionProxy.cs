using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Database.SqlServer.Repositories;
using Microsoft.Extensions.Logging;

namespace CoffeeShop.Infrastructure.Proxy.Proxies;

public class SubscriptionProxy : IProxy<Subscription>
{
    private readonly IRepository<Subscription> _repository;
    private readonly ILogger<SubscriptionProxy> _logger;

    public SubscriptionProxy(IRepository<Subscription> repository, ILogger<SubscriptionProxy> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Subscription> GetByIdAsync(Guid id)
    {
        _logger.LogInformation($"Fetching subscription by ID: {id}");
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Subscription>> GetAllAsync()
    {
        _logger.LogInformation("Fetching all subscriptions");
        return await _repository.GetAllAsync();
    }

    public async Task AddAsync(Subscription coffee)
    {
        _logger.LogInformation($"Adding subscription: {coffee.Name}");
        await _repository.AddAsync(coffee);
    }

    public async Task UpdateAsync(Subscription coffee)
    {
        _logger.LogInformation($"Updating subscription: {coffee.Name}");
        await _repository.UpdateAsync(coffee);
    }

    public async Task DeleteAsync(Guid id)
    {
        _logger.LogInformation($"Deleting subscription by ID: {id}");
        await _repository.DeleteAsync(id);
    }

    public async Task SoftDeleteAsync(Guid id)
    {
        _logger.LogInformation($"Soft deleting subscription by ID: {id}");
        await _repository.SoftDeleteAsync(id);
    }

    public async Task RestoreAsync(Guid id)
    {
        _logger.LogInformation($"Restoring subscription by ID: {id}");
        await _repository.RestoreAsync(id);
    }
}