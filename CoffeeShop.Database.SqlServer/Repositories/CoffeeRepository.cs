using CoffeeShop.Database.SqlServer.Context;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CoffeeShop.Database.Repositories;

public class CoffeeRepository : IRepository<Coffee>
{
    private readonly CoffeeAppDbContext _context;
    private readonly ILogger<CoffeeRepository> _logger;

    public CoffeeRepository(CoffeeAppDbContext context, ILogger<CoffeeRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Coffee> GetByIdAsync(Guid id)
    {
        try
        {
            return await _context.Coffees
                .Include(r => r.Reviews)
                .Include(o => o.Orders)
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
        try
        {
            return await _context.Coffees
                .Include(r => r.Reviews)
                .Include(o => o.Orders)
                .AsSplitQuery()
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting all coffees");
            throw;
        }
    }

    public async Task AddAsync(Coffee entity)
    {
        try
        {
            await _context.Coffees.AddAsync(entity);
            await _context.SaveChangesAsync();
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
}