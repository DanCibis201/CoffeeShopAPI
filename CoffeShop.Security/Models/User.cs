using Microsoft.AspNetCore.Identity;

namespace CoffeShop.Security.Models;

public class User : IdentityUser<Guid>
{
    public string? Initials { get; set; }
}