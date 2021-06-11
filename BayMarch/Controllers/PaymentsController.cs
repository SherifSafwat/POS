using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BayMarch.Services;

namespace BayMarch.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {

        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService categoryService)
        {
            _paymentService = categoryService;
        }

        // GET: api/payments
        [HttpGet]
        [Route("GetDefault")]
        public IActionResult GetDefault()
        {
            return Ok(_paymentService.GetDefault());
        }

    }
}
