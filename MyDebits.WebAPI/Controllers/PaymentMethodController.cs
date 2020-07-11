using Microsoft.AspNetCore.Mvc;
using MyDebits.Domain;
using MyDebits.Repository;

namespace MyDebits.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IMyDebitsRepository _rep;

        public PaymentMethodController(IMyDebitsRepository rep)
        {
            _rep = rep;
        }

        [HttpGet]
        public IActionResult Get()
        {
            PaymentMethod[] payment = _rep.GetAllPaymentMethods();

            return Ok(payment);
        }

        //api/paymentmethod/2
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            PaymentMethod payment = _rep.GetPaymentMethodById(id);

            if (payment == null) return BadRequest("Payment not found!");

            return Ok(payment);
        }
    }
}