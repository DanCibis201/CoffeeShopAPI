//using CoffeeShop.Infrastructure.Core.DependencyInjection;
//using CoffeeShop.Infrastructure.Creational.Prototype;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;

//namespace CoffeeShop.Infrastructure.Creational;

//public class Module : DependencyModule
//{
//    public override void Load(IServiceCollection services)
//    {
//        services.AddTransient<ReviewDatabaseSeeder>();

//        var serviceProvider = services.BuildServiceProvider();

//        var seeder = serviceProvider.GetRequiredService<ReviewDatabaseSeeder>();
//        try
//        {
//            seeder.SeedDatabaseAsync().GetAwaiter().GetResult();
//        }
//        catch (Exception ex)
//        {
//            var logger = serviceProvider.GetRequiredService<ILogger<Module>>();
//            logger.LogError(ex, "An error occurred during database seeding.");
//        }
//    }
//}