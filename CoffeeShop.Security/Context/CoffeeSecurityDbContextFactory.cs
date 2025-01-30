using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CoffeeShop.Security.Context;

public class CoffeeSecurityDbContextFactory : IDesignTimeDbContextFactory<CoffeeSecurityDbContext>
{
    public CoffeeSecurityDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CoffeeSecurityDbContext>();

        optionsBuilder.UseSqlServer("data source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeSecurity;Integrated Security=True;Encrypt=False");

        return new CoffeeSecurityDbContext(optionsBuilder.Options);
    }
}
