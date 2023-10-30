using Loja.Dtos.ProductMapper;
using Loja.Errors;
using Loja.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;


        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAsync()
        {
            var products = await _productService.GetAllProduct();
            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "ProductById")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var product = await _productService.GetProductById(id);
            if (product is null)
            {
                return BadRequest(new ResultError { Sucess = false, Message = $"Product ID {id} Not Found" });
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> PostAsync(PostProductDTO productDTO)
        {
            var product = await _productService.PostProduct(productDTO);
            if (product is null)
            {
                return BadRequest(new ResultError { Sucess = false, Message = $"Error my men" });
            }
            return new CreatedAtRouteResult("ProductById", new { id = product.ProductId }, product); ;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProductDTO>> PutAsync(long id, ProductDTO productDto)
        {
            var product = await _productService.PutProduct(id, productDto);
            if (product is null)
            {
                return BadRequest(new ResultError { Sucess = false, Message = $"Product ID {id} Not Found" });
            }
            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductDTO>> DeleteAsync(long id)
        {
            var product = await _productService.DeleteProduct(id);
            if (product is null)
            {
                return BadRequest(new ResultError { Sucess = false, Message = $"Product ID {id} Not Found" });
            }
            return Ok(product);
        }
    }
}

