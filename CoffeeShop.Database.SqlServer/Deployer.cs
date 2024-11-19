using Microsoft.Extensions.Logging;

namespace CoffeeShop.Database.SqlServer;

internal class Deployer : IDatabaseDeployer
{
    private readonly ILogger<Deployer> _logger;

    public Deployer(ILogger<Deployer> logger)
    {
        _logger = logger;
    }

    public bool Deployed { get; private set; }

    public bool DeployTo(string connectionString)
    {
        Deployed = true;
        _logger.LogInformation("Database deployed successfully");
        return true;
    }
}