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

        [HttpPost]
        public IActionResult Post(Category category)
        {
            _rep.Add(category);
            if(_rep.SaveChanges())
            {
                return Ok(category);
            }

            return BadRequest("Category not found!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Category model)
        {
            var category = _rep.GetCategoryById(id);

            if (category == null) return BadRequest("Category not found!");
            
            _rep.Update(model);

            if(_rep.SaveChanges())
            {
                return Ok(category);
            } 

            return BadRequest("Category was not updated!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _rep.GetCategoryById(id);

            if (category == null) return BadRequest("Category not found!");
            
            _rep.Delete(category);

            if(_rep.SaveChanges())
            {
                return Ok(category);
            } 

            return BadRequest("Category was not deleted!");
        }
        
    }
}