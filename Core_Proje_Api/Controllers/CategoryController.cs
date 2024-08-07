using Core_Proje_Api.DAL.Context;
using Core_Proje_Api.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
           using var c= new Context();
            return Ok(c.Categories.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           using var c = new Context();
           var values = c.Categories.Find(id);
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            using var c = new Context();
            c.Add(p);
            c.SaveChanges();
            return Created("", p);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            using var c = new Context();
            var values = c.Categories.Find(id);
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(values);
                c.SaveChanges();
                return NoContent();
            }

        }
        [HttpPut]
        public IActionResult update(Category p)
        {
            using var c = new Context();
            var values = c.Find<Category>(p.ID);
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                values.CategoryName = p.CategoryName;
                c.Update(values);
                c.SaveChanges();
                return NoContent();
            }
        }
    }
}
