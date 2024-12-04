using CoffeeShop.Application.Commands.CoffeeCommands;
using CoffeeShop.Application.Queries.CoffeeQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoffeeController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<CoffeeController> _logger;

    public CoffeeController(IMediator mediator, ILogger<CoffeeController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> AddCoffeeBrand(CreateCoffeeCommand command)
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
    public async Task<IActionResult> GetAllCoffees()
    {
        try
        {
            var result = await _mediator.Send(new GetAllCoffeesQuery());
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error while getting all coffees. Error message: {ex.Message}");
            throw;
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCoffeeById([FromRoute] Guid id)
    {
        try
        {
            var result = await _mediator.Send(new GetCoffeeByIdQuery(id));
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
    public async Task<IActionResult> DeleteCoffeeById([FromRoute] Guid id)
    {
        try
        {
            await _mediator.Send(new DeleteCoffeeByIdCommand(id));
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error while deleting coffee. Error message: {ex.Message}");
            throw;
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCoffeeById([FromRoute] Guid id, [FromBody] UpdateCoffeeCommand command)
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
            _logger.LogError($"Error while updating coffee. Error message: {ex.Message}");
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error while updating coffee. Error message: {ex.Message}");
            throw;
        }
    }
}