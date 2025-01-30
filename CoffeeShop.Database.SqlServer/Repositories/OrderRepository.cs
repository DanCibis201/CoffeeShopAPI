using CoffeeShop.Database.SqlServer.Context;
using CoffeeShop.Database.SqlServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CoffeeShop.Database.SqlServer.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly CoffeeAppDbContext _context;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(CoffeeAppDbContext context, ILogger<OrderRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            try
            {
                return await _context.Orders.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while getting order by ID: {id}");
                throw;
            }
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            try
            {
                return await _context.Orders.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all orders");
                throw;
            }
        }

        public Task<IEnumerable<Order>> GetAllFilteredAsync(System.Linq.Expressions.Expression<Func<Order, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Order entity)
        {
            try
            {
                await _context.Orders.AddAsync(entity);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Order added successfully: {entity.Id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a new order");
                throw;
            }
        }

        public async Task UpdateAsync(Order entity)
        {
            try
            {
                _context.Orders.Update(entity);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Order updated successfully: {entity.Id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating order: {entity.Id}");
                throw;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);
                if (order != null)
                {
                    _context.Orders.Remove(order);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Order deleted successfully: {order.Id}");
                }
                else
                {
                    _logger.LogWarning($"Order not found: ID {id}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting order by ID: {id}");
                throw;
            }
        }

        public async Task<Order?> GetOrderByCoffeeIdAsync(Guid coffeeId)
        {
            try
            {
                return await _context.Orders.FirstOrDefaultAsync(o => o.CoffeeId == coffeeId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while finding order by coffeeId: {coffeeId}.");
                throw;
            }
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
}