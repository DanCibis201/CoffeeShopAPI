using CoffeeShop.Security.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeShop.Security.DependencyInjection;

public static class ServiceStartup
{
    public static IServiceCollection AddSecurityDbContext(this IServiceCollection service, string connectionString)
    {
        service.AddDbContext<CoffeeSecurityDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        return service;
    }
}