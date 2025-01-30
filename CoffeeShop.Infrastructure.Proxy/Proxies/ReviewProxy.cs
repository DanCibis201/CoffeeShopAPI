using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Database.SqlServer.Repositories;
using Microsoft.Extensions.Logging;

namespace CoffeeShop.Infrastructure.Proxy.Proxies;

public class ReviewProxy : IProxy<Review>
{
    private readonly IRepository<Review> _repository;
    private readonly ILogger<ReviewProxy> _logger;

    public ReviewProxy(IRepository<Review> repository, ILogger<ReviewProxy> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Review> GetByIdAsync(Guid id)
    {
        _logger.LogInformation($"Fetching review by ID: {id}");
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Review>> GetAllAsync()
    {
        _logger.LogInformation("Fetching all reviews");
        return await _repository.GetAllAsync();
    }

    public async Task AddAsync(Review review)
    {
        _logger.LogInformation($"Adding review: {review.Comment}");
        await _repository.AddAsync(review);
    }

    public async Task UpdateAsync(Review review)
    {
        _logger.LogInformation($"Updating review: {review.Comment}");
        await _repository.UpdateAsync(review);
    }

    public async Task DeleteAsync(Guid id)
    {
        _logger.LogInformation($"Deleting review by ID: {id}");
        await _repository.DeleteAsync(id);
    }

    public Task SoftDeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task RestoreAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}