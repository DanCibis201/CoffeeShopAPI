using CoffeeShop.Infrastructure.CoR.Handlers;
using CoffeeShop.Infrastructure.CoR.Services;
using CoffeeShop.Infrastructure.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeShop.Infrastructure.CoR;

public class Module : DependencyModule
{
    public override void Load(IServiceCollection services)
    {
        services.AddScoped<IOrderHandler, StockCheckHandler>();
        services.AddScoped<OrderProcessingService>();

        services.AddTransient<StockCheckHandler>();
        services.AddTransient<OrderProcessingService>();
        services.AddTransient<PaymentHandler>();
    }
}