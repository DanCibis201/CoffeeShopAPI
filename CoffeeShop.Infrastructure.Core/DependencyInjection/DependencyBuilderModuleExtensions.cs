using Microsoft.AspNetCore.Builder;

namespace CoffeeShop.Infrastructure.Core.DependencyInjection;

public static class DependencyBuilderModuleExtensions
{
    private static readonly ICollection<DependencyBuilderModule> _dependencyBuilderModules = new List<DependencyBuilderModule>();

    public static void ConfigureDependencyModules(this IApplicationBuilder app, params Type[] moduleTypes)
    {
        var modules = moduleTypes
            .Select(t => Activator.CreateInstance(t) as DependencyBuilderModule)
            .Where(module => module != null)
            .ToList();

        foreach (var module in modules)
        {
            module.Configure(app);
        }
    }
}