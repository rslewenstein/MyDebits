using Microsoft.AspNetCore.Mvc;
using MyDebits.Domain;
using MyDebits.Repository;
using MyDebits.Dto;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace MyDebits.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DebitController : ControllerBase
    {
        private readonly IMyDebitsRepository _rep;
        private readonly IMapper _mapper;

        public DebitController(IMyDebitsRepository rep, IMapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
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

        // [HttpPost]
        // public IActionResult Post(DebitRegister model)
        // {
        //     var debit = _mapper.Map<Debit>(model);
        //     _rep.Add(debit);
        //     if(_rep.SaveChanges())
        //     {
        //         return Created($"/api/debit/{model.Id}", _mapper.Map<DebitDto>(debit));
        //     }

        //     return BadRequest("Debit not found!");
        // }

        [HttpPost]
        public IActionResult Post(Debit debit)
        {
           // var debit = _mapper.Map<Debit>(model);
            _rep.Add(debit);
            if(_rep.SaveChanges())
            {
                return Created($"/api/debit/{model.Id}", _mapper.Map<DebitDto>(debit));
            }

            return BadRequest("Debit not found!");
        }

    }
}