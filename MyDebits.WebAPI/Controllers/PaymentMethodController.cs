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

        [HttpPost]
        public IActionResult Post(PaymentMethod payment)
        {
            _rep.Add(payment);
            if(_rep.SaveChanges())
            {
                return Ok(payment);
            }

            return BadRequest("Payment Method not found!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, PaymentMethod model)
        {
            var payment = _rep.GetPaymentMethodById(id);

            if (payment == null) return BadRequest("Payment Method not found!");
            
            _rep.Update(model);

            if(_rep.SaveChanges())
            {
                return Ok(payment);
            } 

            return BadRequest("Payment Method was not updated!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var payment = _rep.GetPaymentMethodById(id);

            if (payment == null) return BadRequest("Payment Method not found!");
            
            _rep.Delete(payment);

            if(_rep.SaveChanges())
            {
                return Ok(payment);
            } 

            return BadRequest("Payment Method was not deleted!");
        }
    }
}