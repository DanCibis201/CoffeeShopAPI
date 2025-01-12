using CoffeeShop.Infrastructure.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeShop.Infrastructure.Observer;

public class Module : DependencyModule
{
    public override void Load(IServiceCollection services)
    {
        services.AddSingleton<OrderStatusSubject>(); 
        services.AddTransient<LoggingService>();
        services.AddTransient<UIUpdateService>();
    }
}