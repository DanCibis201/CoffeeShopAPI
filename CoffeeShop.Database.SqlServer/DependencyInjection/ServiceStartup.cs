using CoffeeShop.Database.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeShop.Database.SqlServer.DependencyInjection;

public static class ServiceStartup
{
    public static IServiceCollection AddCoffeeDbContext(this IServiceCollection service, string connectionString)
    {
        service.AddDbContext<CoffeeAppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        return service;
    }
}