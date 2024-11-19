using CoffeeShop.Application.Commands.OrderCommands;
using CoffeeShop.Application.Queries.OrderQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<OrderController> _logger;

    public OrderController(IMediator mediator, ILogger<OrderController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
    {
        try
        {
            await _mediator.Send(command);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error while creating order. Error message: {ex.Message}");
            throw;
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        try
        {
            var result = await _mediator.Send(new GetAllOrdersQuery());
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error while getting all the orders. Error message: {ex.Message}");
            throw;
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById([FromRoute] Guid id)
    {
        try
        {
            var result = await _mediator.Send(new GetOrderByIdQuery(id));
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
    public async Task<IActionResult> DeleteOrderById([FromRoute] Guid id)
    {
        try
        {
            await _mediator.Send(new DeleteOrderByIdCommand(id));
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error while deleting coffee. Error message: {ex.Message}");
            throw;
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrderById([FromRoute] Guid id, [FromBody] UpdateOrderCommand command)
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
            _logger.LogError($"Error while updating order. Error message: {ex.Message}");
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error while updating order. Error message: {ex.Message}");
            throw;
        }
    }
}