using CoffeeShop.Database.SqlServer.Context;
using EFCore.AutomaticMigrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoffeeShop.Database.SqlServer.AutoMigration;

public static class StartupDbExtensions
{
    public static async void CreateDbIfDoesNotExist(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        var coffeeContext = services.GetRequiredService<CoffeeAppDbContext>();
        coffeeContext.Database.EnsureCreated();

        await coffeeContext.MigrateToLatestVersionAsync();
    }
}