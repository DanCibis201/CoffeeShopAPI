using CoffeeShop.Database.SqlServer.Context;
using CoffeeShop.Database.SqlServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace CoffeeShop.Database.SqlServer.Repositories;

public class CoffeeRepository : IRepository<Coffee>
{
    private readonly CoffeeAppDbContext _context;
    private readonly ILogger<CoffeeRepository> _logger;
    private readonly IMemoryCache _cache;
    private readonly TimeSpan _cacheDuration = TimeSpan.FromDays(1);
    private const string CoffeeCacheKey = "CoffeeList";

    public CoffeeRepository(CoffeeAppDbContext context, ILogger<CoffeeRepository> logger, IMemoryCache cache)
    {
        _context = context;
        _logger = logger;
        _cache = cache;
    }

    public async Task<Coffee> GetByIdAsync(Guid id)
    {
        try
        {
            return await _context.Coffees
                .Include(r => r.Reviews)
                .Include(o => o.Orders)
                .AsSplitQuery()
                .FirstOrDefaultAsync(c => c.Id == id)!;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while getting coffee by ID: {id}");
            throw;
        }
    }

    public async Task<IEnumerable<Coffee>> GetAllAsync()
    {
        if (!_cache.TryGetValue(CoffeeCacheKey, out IEnumerable<Coffee>? coffees))
        {
            _logger.LogInformation("Fetching coffee list from database...");
            coffees = await _context.Coffees.Where(c => !c.IsDeleted).ToListAsync();

            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(_cacheDuration)
                .SetSlidingExpiration(TimeSpan.FromMinutes(10));

            _cache.Set(CoffeeCacheKey, coffees, cacheOptions);
        }
        else
        {
            _logger.LogInformation("Fetching coffee list from cache...");
        }

        return coffees!;
    }

    public async Task AddAsync(Coffee entity)
    {
        try
        {
            await _context.Coffees.AddAsync(entity);
            await _context.SaveChangesAsync();
            _cache.Remove(CoffeeCacheKey);
            _logger.LogInformation($"Coffee added successfully: {entity.Name}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adding a new coffee");
            throw;
        }
    }

    public async Task UpdateAsync(Coffee entity)
    {
        try
        {
            _context.Coffees.Update(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Coffee updated successfully: {entity.Name}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while updating coffee: {entity.Name}");
            throw;
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        try
        {
            var coffee = await _context.Coffees.FindAsync(id);
            if (coffee != null)
            {
                _context.Coffees.Remove(coffee);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Coffee deleted successfully: {coffee.Name}");
            }
            else
            {
                _logger.LogWarning($"Coffee not found: ID {id}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while deleting coffee by ID: {id}");
            throw;
        }
    }

    public async Task SoftDeleteAsync(Guid id)
    {
        try
        {
            var coffee = await _context.Coffees.FindAsync(id);
            if (coffee != null)
            {
                coffee.IsDeleted = true;
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Coffee soft deleted successfully: {coffee.Name}");
            }
            else
            {
                _logger.LogWarning($"Coffee not found: ID {id}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while soft deleting coffee by ID: {id}");
            throw;
        }
    }

    public async Task RestoreAsync(Guid id)
    {
        try
        {
            var coffee = await _context.Coffees
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (coffee != null)
            {
                coffee.IsDeleted = false;
                _context.Coffees.Update(coffee);

                await _context.SaveChangesAsync();
                _logger.LogInformation($"Coffee restored successfully: {coffee.Name}");
            }
            else
            {
                _logger.LogWarning($"Coffee not found: ID {id}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while restoring coffee by ID: {id}");
            throw;
        }
    }
}