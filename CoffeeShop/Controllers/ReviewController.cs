using CoffeeShop.Application.Commands.ReviewCommands;
using CoffeeShop.Application.Queries.ReviewQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ReviewController> _logger;

    public ReviewController(IMediator mediator, ILogger<ReviewController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> AddReview(CreateReviewCommand command)
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
    public async Task<IActionResult> GetAllReviews()
    {
        try
        {
            var result = await _mediator.Send(new GetAllReviewsQuery());
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error while getting all reviews. Error message: {ex.Message}");
            throw;
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCoffeeById([FromRoute] Guid id)
    {
        try
        {
            var result = await _mediator.Send(new GetReviewByIdQuery(id));
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
    public async Task<IActionResult> DeleteReviewById([FromRoute] Guid id)
    {
        try
        {
            await _mediator.Send(new DeleteReviewByIdCommand(id));
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error while deleting review. Error message: {ex.Message}");
            throw;
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReviewById([FromRoute] Guid id, [FromBody] UpdateReviewCommand command)
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
            _logger.LogError($"Error while updating review. Error message: {ex.Message}");
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error while updating review. Error message: {ex.Message}");
            throw;
        }
    }
}