using Microsoft.AspNetCore.Identity;

namespace CoffeeShop.Security.Models;

public class User : IdentityUser
{
    public string? Initials { get; set; }
}