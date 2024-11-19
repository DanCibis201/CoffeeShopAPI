using Microsoft.Extensions.DependencyInjection;

namespace CoffeeShop.Infrastructure.Core.DependencyInjection;

public abstract class DependencyModule
{
    public abstract void Load(IServiceCollection services);
}