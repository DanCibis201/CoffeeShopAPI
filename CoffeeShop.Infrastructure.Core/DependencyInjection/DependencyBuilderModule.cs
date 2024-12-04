using Microsoft.AspNetCore.Builder;

namespace CoffeeShop.Infrastructure.Core.DependencyInjection;

public abstract class DependencyBuilderModule
{
    public abstract void Configure(IApplicationBuilder app);
}