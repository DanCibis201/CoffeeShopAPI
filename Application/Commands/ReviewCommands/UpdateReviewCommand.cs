using MediatR;
using System.Text.Json.Serialization;

namespace CoffeeShop.Application.Commands.ReviewCommands;

public class UpdateReviewCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public Guid CoffeeId { get; set; }
    public string? UserName { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
    
    [JsonConstructor]
    public UpdateReviewCommand(Guid id, Guid coffeeId, 
        string userName, string comment, int rating)
    {
        Id = id;
        CoffeeId = coffeeId;
        UserName = userName;
        Comment = comment;
        Rating = rating;
    }
}