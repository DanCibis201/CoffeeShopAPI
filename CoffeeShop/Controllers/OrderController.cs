using CoffeeShop.Application.Commands.OrderCommands;
using CoffeeShop.Application.Queries.OrderQueries;
using CoffeeShop.Database.SqlServer.Entities;
using CoffeeShop.Infrastructure.CoR.Handlers;
using CoffeeShop.Infrastructure.CoR.Services;
using CoffeeShop.Infrastructure.Observer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<OrderController> _logger;
    private readonly IServiceProvider _serviceProvider;

    public OrderController(IMediator mediator, ILogger<OrderController> logger, IServiceProvider serviceProvider)
    {
        _mediator = mediator;
        _logger = logger;
        _serviceProvider = serviceProvider;
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

            var orderStatus = _serviceProvider.GetService<OrderStatusSubject>();
            var dashboardUpdate = _serviceProvider.GetService<LoggingService>();
            var updateService = _serviceProvider.GetService<UIUpdateService>();

            _logger.LogInformation($"Observing the processes for the following order with ID: {id}");

            orderStatus.Attach(dashboardUpdate);
            orderStatus.Attach(updateService);

            var product = new Order { Id = id };
            orderStatus.UpdateOrderStatus(product);

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

    [HttpPost("upsert")]
    public async Task<IActionResult> UpsertOrder([FromBody] UpsertOrderCommand command)
    {
        try
        {
            var order = await _mediator.Send(command);

            var stockCheckHandler = _serviceProvider.GetService<StockCheckHandler>();
            var orderPlacementHandler = _serviceProvider.GetService<OrderPlacementHandler>();
            var paymentHandler = _serviceProvider.GetService<PaymentHandler>();

            stockCheckHandler.SetNext(paymentHandler);

            var orderProcessingService = new OrderProcessingService(stockCheckHandler);
            orderProcessingService.ProcessOrder(order);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error while upserting order. Message: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }
}