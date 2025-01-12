using CoffeeShop.Database.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CoffeeShop.Infrastructure.Creational.Prototype;

public class ReviewDatabaseSeeder
{
    private readonly CoffeeAppDbContext _context;
    private readonly ILogger<ReviewDatabaseSeeder> _logger;

    public ReviewDatabaseSeeder(CoffeeAppDbContext context, ILogger<ReviewDatabaseSeeder> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task SeedDatabaseAsync()
    {
        _logger.LogInformation("Starting database seeding process...");

        var coffeeId = await _context.Coffees.AsNoTracking().Select(c => c.Id).FirstOrDefaultAsync();
        if (coffeeId == Guid.Empty)
        {
            _logger.LogWarning("No coffees found in the database. Skipping review seeding.");
            return;
        }

        var existingReview = await _context.Reviews.AsNoTracking().FirstOrDefaultAsync();
        if (existingReview != null)
        {
            _logger.LogWarning("A review already exists. Skipping review seeding.");
            return;
        }

        var prototype = new ReviewPrototype(null);
        var newReview = prototype.CreateNewReview(
            userName: "AdminSeeder",
            comment: "This is a seeded review for testing purposes.",
            rating: 5,
            coffeeId: coffeeId
        );

        _context.Reviews.Add(newReview);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Successfully seeded a review into the database.");
    }
}