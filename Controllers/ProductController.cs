using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ProductsCategoryAPI.Models;
using ProductsCategoryAPI.Services.ProductBuildService;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ProductsCategoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBuildService _productBuildService;
        public ProductController(IProductBuildService productBuildService)
        {
            _productBuildService = productBuildService;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            return Ok(_productBuildService.GetAllProducts());
        }
        [HttpGet("{productName}")]
        public async Task<IActionResult> ListByPropertyResult(string productName, string value)
        {
            var results = await _productBuildService.SearchByPropertyAsync(productName, value);
            return Ok(results);
        }
        [HttpPost]
        public IActionResult ProductAddition(ProductBuild productBuild)
        {
            productBuild.Id = ObjectId.GenerateNewId().ToString();
            _productBuildService.AddProduct(productBuild);
            return Ok(new { id = productBuild.Id });
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteImage(string id)
        {
            _productBuildService.DeleteProduct(id);
            return NoContent();
        }
    }
}
