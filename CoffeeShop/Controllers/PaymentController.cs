using CoffeeShop.Infrastructure.Payment.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        [HttpPost("creditcard")]
        public IActionResult ProcessCreditCardPayment([FromBody] PaymentRequest request)
        {
            var paymentMethod = new CreditCardPayment();
            var paymentSystem = new PaymentProcessor(paymentMethod);
            paymentSystem.MakePayment(request.Amount);
            return Ok(new { message = $"Credit card payment successfully completed." });
        }

        [HttpPost("cash")]
        public IActionResult ProcessCashPayment([FromBody] PaymentRequest request)
        {
            var paymentMethod = new CashPayment();
            var paymentSystem = new PaymentProcessor(paymentMethod);
            paymentSystem.MakePayment(request.Amount);
            return Ok(new { message = $"Cash payment successfully completed." });
        }
    }
}