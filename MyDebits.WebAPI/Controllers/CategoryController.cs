using Microsoft.AspNetCore.Mvc;
using MyDebits.Domain;
using MyDebits.Repository;

namespace MyDebits.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMyDebitsRepository _rep;

        public CategoryController(IMyDebitsRepository rep)
        {
            _rep = rep;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Category[] category = _rep.GetAllCategories();

            return Ok(category);
        }

        //api/category/2
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Category category = _rep.GetCategoryById(id);

            if (category == null) return BadRequest("Category not found!");

            return Ok(category);
        }
        
    }
}