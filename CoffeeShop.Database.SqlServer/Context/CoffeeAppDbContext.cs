using CoffeeShop.Database.SqlServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Database.SqlServer.Context;

public class CoffeeAppDbContext : DbContext
{
    public CoffeeAppDbContext(DbContextOptions<CoffeeAppDbContext> options) : base(options) { }

    public DbSet<Coffee> Coffees { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region CoffeeBuilder
        modelBuilder.Entity<Coffee>()
            .ToTable("Coffees")
            .HasKey(c => c.Id);
        modelBuilder.Entity<Coffee>()
            .HasMany(c => c.Reviews)
            .WithOne(r => r.Coffee)
            .HasForeignKey(r => r.CoffeeId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Coffee>()
            .HasMany(o => o.Orders)
            .WithOne(r => r.Coffee)
            .HasForeignKey(r => r.CoffeeId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Coffee>()
            .Property(c => c.Price)
            .HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Coffee>()
            .Property(c => c.Description)
            .HasColumnType("nvarchar(max)");
        modelBuilder.Entity<Coffee>()
            .Property(c => c.ImageUrl)
            .HasColumnType("nvarchar(max)");
        #endregion

        #region ReviewBuilder
        modelBuilder.Entity<Review>()
            .ToTable("Reviews")
            .HasKey(r => r.Id);
        #endregion

        #region OrderBuilder
        modelBuilder.Entity<Order>()
            .ToTable("Orders")
            .HasKey(o => o.Id);
        #endregion

        base.OnModelCreating(modelBuilder);
    }
}