using MediatR;

namespace CoffeeShop.Application.Commands.ReviewCommands;

public class CreateReviewCommand : IRequest<Unit>
{
    public Guid CoffeeId { get; set; }
    public string UserName { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
}