using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Database.SqlServer.Entities;

public class Review
{
    public Guid Id { get; set; }
    public Guid CoffeeId { get; set; }
    public string? UserName { get; set; }
    public string Comment { get; set; }

    [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10")]
    public int Rating { get; set; }

    public Coffee? Coffee { get; set; }
}