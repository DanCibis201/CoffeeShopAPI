using CoffeeShop.Application.Commands.SubscriptionCommands;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Database.SqlServer.Repositories;
using MediatR;

namespace CoffeeShop.Application.Handlers.SubscriptionHandlers;

public class CreateSubscriptionHandler : IRequestHandler<UpsertSubscriptionCommand>
{
    private readonly SubscriptionRepository _subscriptionRepository;

    public CreateSubscriptionHandler(SubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public async Task Handle(UpsertSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var existingSubscription = await _subscriptionRepository.GetSubscriptionDetailsAsync(request.Name);
        if (existingSubscription != null)
        {
            existingSubscription.Name = request.Name;
            existingSubscription.Cost = request.Cost;
            existingSubscription.Benefits = request.Benefits;

            await _subscriptionRepository.UpdateAsync(existingSubscription);
        }
        else
        {
            var newSubscription = new Subscription
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Cost = request.Cost,
                Benefits = request.Benefits
            };
            await _subscriptionRepository.AddAsync(newSubscription);
        }
    }
}