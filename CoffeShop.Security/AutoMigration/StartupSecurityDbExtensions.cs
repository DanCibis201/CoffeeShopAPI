using CoffeeShop.Security.Context;
using EFCore.AutomaticMigrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoffeeShop.Security.AutoMigration;

public static class StartupSecurityDbExtensions
{
    public static async void CreateSecurityDbIfDoesNotExist(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        var securityContext = services.GetRequiredService<CoffeeSecurityDbContext>();
        var isDatabaseCreated = securityContext.Database.EnsureCreated();

        if (!isDatabaseCreated)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CoffeeSecurityDbContext>();
            optionsBuilder.UseSqlServer(services.GetRequiredService<IConfiguration>().GetConnectionString("SecurityConnection"));
            
            using var newSecurityContext = new CoffeeSecurityDbContext(optionsBuilder.Options);
            await newSecurityContext.Database.EnsureCreatedAsync();
        }
        else
            await securityContext.MigrateToLatestVersionAsync();
    }
}