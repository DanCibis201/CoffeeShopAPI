using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.Core.DependencyInjection;
using CoffeeShop.Infrastructure.Proxy.Proxies;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeShop.Infrastructure.Proxy;

public class Module : DependencyModule
{
    public override void Load(IServiceCollection services)
    {
        services.AddScoped<IProxy<Coffee>, CoffeeProxy>();
        services.AddScoped<IProxy<Order>, OrderProxy>();
        services.AddScoped<IProxy<Review>, ReviewProxy>();
        services.AddScoped<IProxy<Subscription>, SubscriptionProxy>();
    }
}