using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CoffeeShop.Database.SqlServer.Context;

public class CoffeeDbContextFactory : IDesignTimeDbContextFactory<CoffeeAppDbContext>
{
    public CoffeeAppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CoffeeAppDbContext>();

        optionsBuilder.UseSqlServer("data source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeCQRSDB;Integrated Security=True;Encrypt=False");

        return new CoffeeAppDbContext(optionsBuilder.Options);
    }
}
