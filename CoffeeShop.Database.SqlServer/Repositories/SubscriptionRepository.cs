using CoffeeShop.Database.SqlServer.Context;
using CoffeeShop.Database.SqlServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CoffeeShop.Database.SqlServer.Repositories;

public class SubscriptionRepository : IRepository<Subscription>
{
    private readonly CoffeeAppDbContext _context;
    private readonly ILogger<SubscriptionRepository> _logger;

    public SubscriptionRepository(CoffeeAppDbContext context, ILogger<SubscriptionRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Subscription> GetByIdAsync(Guid id)
    {
        try
        {
            return await _context.Subscriptions
                .FirstOrDefaultAsync(s => s.Id == id)!;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while getting subscription by ID: {id}");
            throw;
        }
    }

    public async Task<IEnumerable<Subscription>> GetAllAsync()
    {
        try
        {
            return await _context.Subscriptions.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting all subscriptions");
            throw;
        }
    }

    public async Task AddAsync(Subscription entity)
    {
        try
        {
            await _context.Subscriptions.AddAsync(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Subscription added successfully: {entity.Name}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adding a new subscription");
            throw;
        }
    }

    public async Task UpdateAsync(Subscription entity)
    {
        try
        {
            _context.Subscriptions.Update(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Subscription updated successfully: {entity.Name}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while updating subscription: {entity.Name}");
            throw;
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        try
        {
            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription != null)
            {
                _context.Subscriptions.Remove(subscription);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Subscription deleted successfully: {subscription.Name}");
            }
            else
            {
                _logger.LogWarning($"Subscription not found: ID {id}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while deleting subscription by ID: {id}");
            throw;
        }
    }

    public async Task<Subscription?> GetSubscriptionDetailsAsync(string name)
    {
        try
        {
            return await _context.Subscriptions.FirstOrDefaultAsync(s => s.Name == name);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occured while finding subscriptions by name: {name}");
            throw;
        }
    }

    public async Task SoftDeleteAsync(Guid id)
    {
        try
        {
            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription != null)
            {
                subscription.IsDeleted = true;
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Subscription soft deleted successfully: {subscription.Name}");
            }
            else
            {
                _logger.LogWarning($"Subscription not found: ID {id}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while soft deleting subscription by ID: {id}");
            throw;
        }
    }

    public async Task RestoreAsync(Guid id)
    {
        try
        {
            var subscription = await _context.Subscriptions
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (subscription != null)
            {
                subscription.IsDeleted = false;
                _context.Subscriptions.Update(subscription);

                await _context.SaveChangesAsync();
                _logger.LogInformation($"Subscription restored successfully: {subscription.Name}");
            }
            else
            {
                _logger.LogWarning($"Subscription not found: ID {id}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while restoring subscription by ID: {id}");
            throw;
        }
    }
}