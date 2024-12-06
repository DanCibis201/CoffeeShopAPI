using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Database.SqlServer.Entities;

public class Review
{
    public Guid Id { get; set; }
    public Guid CoffeeId { get; set; }
    public string? UserName { get; set; }
    public string Comment { get; set; }

    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
    public int Rating { get; set; }

    public Coffee? Coffee { get; set; }
}