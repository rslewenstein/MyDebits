using Microsoft.AspNetCore.Mvc;
using MyDebits.Domain;
using MyDebits.Repository;

namespace MyDebits.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DebitController : ControllerBase
    {
        private readonly IMyDebitsRepository _rep;

        public DebitController(IMyDebitsRepository rep)
        {
            _rep = rep;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Debit[] debit = _rep.GetAllDebits();

            return Ok(debit);
        }

        //api/debit/2
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Debit debit = _rep.GetDebitById(id);

            if (debit == null) return BadRequest("Debit not found!");

            return Ok(debit);
        }
    }
}