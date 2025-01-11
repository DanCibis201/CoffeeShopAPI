using MediatR;

namespace CoffeeShop.Application.Commands.ReviewCommands;

public class UpsertReviewCommand : IRequest
{
    public Guid CoffeeId { get; set; }
    public string UserName { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
}
