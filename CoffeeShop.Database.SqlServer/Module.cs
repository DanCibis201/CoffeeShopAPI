using CoffeeShop.Database.Repositories;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Core.DependencyInjection;
using CoffeeShop.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeShop.Database.SqlServer;

public class Module : DependencyModule
{
    public override void Load(IServiceCollection services)
    {
        services.AddSingleton<IDatabaseDeployer, Deployer>();

        services.AddScoped<IRepository<Coffee>, CoffeeRepository>();
        services.AddScoped<IRepository<Review>, ReviewRepository>();
        services.AddScoped<IRepository<Order>, OrderRepository>();
    }
}