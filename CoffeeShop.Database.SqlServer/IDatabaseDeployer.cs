namespace CoffeeShop.Database.SqlServer;

public interface IDatabaseDeployer
{
    bool DeployTo(string connectionString);
    bool Deployed { get; }
}