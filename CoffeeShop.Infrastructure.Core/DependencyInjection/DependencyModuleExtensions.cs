using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CoffeeShop.Infrastructure.Core.DependencyInjection;

public static class DependencyModuleExtensions
{
    private static readonly ICollection<DependencyModule> _dependencyModules = new List<DependencyModule>();

    public static void LoadDependencyModules(this IServiceCollection services, params Assembly[] assemblies)
    {
        foreach (var assembly in assemblies)
        {
            var modules = assembly
                .GetTypes()
                .Where(x => !x.IsAbstract && typeof(DependencyModule).IsAssignableFrom(x))
                .ToArray();

            foreach (var module in modules)
            {
                var instance = Activator.CreateInstance(module);
                if (instance is not DependencyModule dependencyModule) continue;

                _dependencyModules.Add(dependencyModule);

                dependencyModule.Load(services);
            }
        }
    }
}
