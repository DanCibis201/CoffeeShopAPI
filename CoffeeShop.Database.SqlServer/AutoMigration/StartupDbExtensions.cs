using CoffeeShop.Database.SqlServer.Context;
using EFCore.AutomaticMigrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        var isDatabaseCreated = coffeeContext.Database.EnsureCreated();

        if (isDatabaseCreated)
            await coffeeContext.MigrateToLatestVersionAsync(new DbMigrationsOptions { ResetDatabaseSchema = false });
        else
        {
            var optionsBuilder = new DbContextOptionsBuilder<CoffeeAppDbContext>();
            optionsBuilder.UseSqlServer(services.GetRequiredService<IConfiguration>().GetConnectionString("DatabaseConnection"));

            using var newCoffeeContext = new CoffeeAppDbContext(optionsBuilder.Options);
            await newCoffeeContext.Database.EnsureCreatedAsync();
            await newCoffeeContext.Database.MigrateAsync();
        }
    }
}