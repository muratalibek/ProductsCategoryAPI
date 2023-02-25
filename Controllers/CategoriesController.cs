using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using ProductsCategoryAPI.Models;
using ProductsCategoryAPI.Services.CategoryService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsCategoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult ListOfCategories()
        {
            return Ok(_categoryService.GetAllCategories());
        }
        [HttpGet("{categoryName}")]
        public async Task<IActionResult> ListByPropertyResult(string categoryName, string value)
        {
            var results = await _categoryService.SearchByPropertyAsync(categoryName, value);
            return Ok(results);
        }
        [HttpPost("categoryroute")]
        public IActionResult CategoryAddition(Categories category)
        {
            category.Id = ObjectId.GenerateNewId().ToString();
            _categoryService.AddCategory(category);
            return CreatedAtRoute("GetCategory", new { id = category.Id }, category);
        }

        [HttpDelete("{id}")]
        public IActionResult CategoryRemoval(string id)
        {
            _categoryService.DeleteCategory(id);
            return NoContent();
        }
    }
}
