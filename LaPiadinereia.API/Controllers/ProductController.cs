using LaPiadinereia.API.Dtos;
using LaPiadinereia.API.Models;
using LaPiadinereia.API.Services.ProductDataService;
using Microsoft.AspNetCore.Mvc;

namespace LaPiadinereia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductDataService _productDataService;

        public ProductController(IProductDataService productDataService)
        {
            _productDataService = productDataService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productDataService.GetProducts());
        }

        [HttpGet("{productId:int}")]
        public IActionResult GetProduct(int productId)
        {
            try
            {
                return Ok(_productDataService.GetProducts().First(x => x.Id == productId));
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpDelete("{productId:int}")]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                var x = _productDataService.GetProducts().First(x => x.Id == productId);
                _productDataService.DeleteProduct(x);
                return NoContent();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
