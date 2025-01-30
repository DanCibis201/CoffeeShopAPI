using Microsoft.AspNetCore.Identity;

namespace CoffeeShop.Security.Models;

public class User : IdentityUser
{
    public string? Initials { get; set; }
    public Guid? SubscriptionId { get; set; }
    public bool HasSubscription { get; set; } = false;
    public int? LoyaltyPoints { get; set; }
    public DateTime? SubscriptionEndDate { get; set; }
}