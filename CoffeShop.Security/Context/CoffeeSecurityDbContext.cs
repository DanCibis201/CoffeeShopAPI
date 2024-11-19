using CoffeShop.Security.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoffeShop.Security.Context;

public class CoffeeSecurityDbContext : IdentityDbContext<User, Role, Guid>
{
    public CoffeeSecurityDbContext(DbContextOptions<CoffeeSecurityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .Property(u => u.Initials)
            .HasMaxLength(5);

        modelBuilder.HasDefaultSchema("security");
    }
}