using CoffeeShop.Database.SqlServer.Context;
using CoffeeShop.Database.SqlServer.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Database.SqlServer.Repositories;

public class Repository<T> where T : class, ISoftDeletable
{
    private readonly CoffeeAppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(CoffeeAppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task SoftDeleteAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }

    public async Task RestoreAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            entity.IsDeleted = false;
            await _context.SaveChangesAsync();
        }
    }
}