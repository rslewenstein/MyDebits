using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MyDebits.Domain;
using MyDebits.Repository;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        public IActionResult Post(Debit debit)
        {
            _rep.Add(debit);
            if(_rep.SaveChanges())
            {
                return Ok(debit);
            }

            return BadRequest("Debit not found!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Debit model)
        {
            var debit = _rep.GetDebitById(id);

            if (debit == null) return BadRequest("Debit not found!");
            
            _rep.Update(model);

            if(_rep.SaveChanges())
            {
                return Ok(debit);
            } 

            return BadRequest("Debit was not updated!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var debit = _rep.GetDebitById(id);

            if (debit == null) return BadRequest("Debit not found!");
            
            _rep.Delete(debit);

            if(_rep.SaveChanges())
            {
                return Ok(debit);
            } 

            return BadRequest("Debit was not deleted!");
        }

    }
}