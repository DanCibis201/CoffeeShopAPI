using CoffeeShop.Database.SqlServer.Context;
using CoffeeShop.Database.SqlServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CoffeeShop.Database.SqlServer.Repositories;

public class ReviewRepository : IRepository<Review>
{
    private readonly CoffeeAppDbContext _context;
    private readonly ILogger<ReviewRepository> _logger;

    public ReviewRepository(CoffeeAppDbContext context, ILogger<ReviewRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Review> GetByIdAsync(Guid id)
    {
        try
        {
            return await _context.Reviews.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while getting review by ID: {id}");
            throw;
        }
    }

    public async Task<IEnumerable<Review>> GetAllAsync()
    {
        try
        {
            return await _context.Reviews.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting all reviews");
            throw;
        }
    }

    public async Task AddAsync(Review entity)
    {
        try
        {
            await _context.Reviews.AddAsync(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Review added successfully!");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adding a new review");
            throw;
        }
    }

    public async Task UpdateAsync(Review entity)
    {
        try
        {
            _context.Reviews.Update(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Review updated successfully!");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while updating review!");
            throw;
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        try
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Review deleted successfully!");
            }
            else
            {
                _logger.LogWarning($"Review not found: ID {id}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while deleting review by ID: {id}");
            throw;
        }
    }

    public async Task<Review?> GetUserReviewByCoffeeIdAsync(Guid coffeeId, string userName)
    {
        try
        {
            return await _context.Reviews.FirstOrDefaultAsync(o => o.CoffeeId == coffeeId &&    
                                                                   o.UserName == userName);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while finding review by coffeeId: {coffeeId} for user name: {userName}.");
            throw;
        }
    }
}