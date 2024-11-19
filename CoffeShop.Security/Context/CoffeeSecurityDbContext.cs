using CoffeeShop.Security.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Security.Context;

public class CoffeeSecurityDbContext : IdentityDbContext<User>
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