using CoffeeShop.Application.Commands.SubscriptionCommands;
using CoffeeShop.Application.Queries.SubscriptionQueries;
using CoffeeShop.Database.SqlServer.Context;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Dto;
using CoffeeShop.Security.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoffeeShop.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class SubscriptionController(
             IMediator mediator,
             ILogger<SubscriptionController> logger,
             UserManager<User> userManager,
             CoffeeAppDbContext context) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly ILogger<SubscriptionController> _logger = logger;
    private readonly UserManager<User> _userManager = userManager;
    private readonly CoffeeAppDbContext _context = context;

    [HttpPost("upsert")]
    public async Task<IActionResult> AddSubscriptionPlan(UpsertSubscriptionCommand command)
    {
        try
        {
            await _mediator.Send(command);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error while submitting request. Error message {ex.Message}");
            throw;
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSubscriptions()
    {
        try
        {
            var result = await _mediator.Send(new GetAllSubscriptionsQuery());
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error while getting all subscriptions. Error message: {ex.Message}");
            throw;
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSubscriptionById([FromRoute] Guid id)
    {
        try
        {
            var result = await _mediator.Send(new GetSubscriptionByIdQuery(id));
            if (result is not null)
                return Ok(result);
            else
                return NotFound();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error while getting request. Error message: {ex.Message}");
            throw;
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSubscriptionById([FromRoute] Guid id)
    {
        try
        {
            await _mediator.Send(new DeleteSubscriptionByIdCommand(id));
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error while deleting subscription. Error message: {ex.Message}");
            throw;
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSubscriptionById([FromRoute] Guid id, [FromBody] UpdateSubscriptionCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("ID in the URL does not match ID in the request body");
        }

        try
        {
            await _mediator.Send(command);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            _logger.LogError($"Error while updating subscription. Error message: {ex.Message}");
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error while updating subscription. Error message: {ex.Message}");
            throw;
        }
    }

    [Authorize]
    [HttpPost("purchase")]
    public async Task<IActionResult> PurchaseSubscription([FromBody] PurchaseSubscriptionDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
            return Unauthorized("User not found");

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return NotFound("User not found");

        var subscription = await _context.Set<Subscription>().FindAsync(dto.SubscriptionId);
        if (subscription == null)
            return NotFound("Subscription not found");

        DateTime subscriptionEndDate;
        int loyaltyPoints;

        if (subscription.Cost == 200)
        {
            subscriptionEndDate = DateTime.UtcNow.AddMonths(1);
            loyaltyPoints = 10;
        }
        else if (subscription.Cost == 450)
        {
            subscriptionEndDate = DateTime.UtcNow.AddMonths(3);
            loyaltyPoints = 30;
        }
        else if (subscription.Cost == 1000)
        {
            subscriptionEndDate = DateTime.UtcNow.AddMonths(6);
            loyaltyPoints = 60;
        }
        else
        {
            return BadRequest("Invalid subscription cost");
        }

        user.SubscriptionId = subscription.Id;
        user.HasSubscription = true;
        user.LoyaltyPoints = (user.LoyaltyPoints ?? 0) + loyaltyPoints;
        user.SubscriptionEndDate = subscriptionEndDate;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
            return BadRequest("Failed to update user subscription");

        return Ok(new { message = "Subscription purchased successfully", subscriptionEndDate, loyaltyPoints });
    }

    [HttpPost("{id}/restore")]
    public async Task<IActionResult> RestoreCoffeeById([FromRoute] Guid id)
    {
        try
        {
            await _mediator.Send(new RestoreSubscriptionByIdCommand(id));
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error while restoring coffee. Error message: {ex.Message}");
            throw;
        }
    }
}