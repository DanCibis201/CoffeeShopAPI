using CoffeeShop.Infrastructure.Payment.Implementations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(IMediator mediator, ILogger<PaymentController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("creditcard")]
        public IActionResult ProcessCreditCardPayment(decimal amount)
        {
            var paymentMethod = new CreditCardPayment();
            var paymentSystem = new PaymentProcessor(paymentMethod);
            paymentSystem.MakePayment(amount);
            return Ok(new { message = "Credit card payment successfully completed." });
        }

        [HttpPost("cash")]
        public IActionResult ProcessCashPayment(decimal amount)
        {
            var paymentMethod = new CashPayment();
            var paymentSystem = new PaymentProcessor(paymentMethod);
            paymentSystem.MakePayment(amount);
            return Ok(new { message = "Cash payment successfully completed." });
        }
    }
}
