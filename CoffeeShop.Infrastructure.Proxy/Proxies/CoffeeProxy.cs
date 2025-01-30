using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Database.SqlServer.Repositories;
using Microsoft.Extensions.Logging;

namespace CoffeeShop.Infrastructure.Proxy.Proxies;

public class CoffeeProxy : IProxy<Coffee>
{
    private readonly IRepository<Coffee> _repository;
    private readonly ILogger<CoffeeProxy> _logger;

    public CoffeeProxy(IRepository<Coffee> repository, ILogger<CoffeeProxy> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Coffee> GetByIdAsync(Guid id)
    {
        _logger.LogInformation($"Fetching coffee by ID: {id}");
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Coffee>> GetAllAsync()
    {
        _logger.LogInformation("Fetching all coffees");
        return await _repository.GetAllAsync();
    }

    public async Task AddAsync(Coffee coffee)
    {
        _logger.LogInformation($"Adding coffee: {coffee.Name}");
        await _repository.AddAsync(coffee);
    }

    public async Task UpdateAsync(Coffee coffee)
    {
        _logger.LogInformation($"Updating coffee: {coffee.Name}");
        await _repository.UpdateAsync(coffee);
    }

    public async Task DeleteAsync(Guid id)
    {
        _logger.LogInformation($"Deleting coffee by ID: {id}");
        await _repository.DeleteAsync(id);
    }

    public async Task SoftDeleteAsync(Guid id)
    {
        _logger.LogInformation($"Soft deleting coffee by ID: {id}");
        await _repository.SoftDeleteAsync(id);
    }

    public async Task RestoreAsync(Guid id)
    {
        _logger.LogInformation($"Restoring coffee by ID: {id}");
        await _repository.RestoreAsync(id);
    }
}