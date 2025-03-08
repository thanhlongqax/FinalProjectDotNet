using Gimji.DTO;
using Gimji.Models;
using Gimji.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gimji.Controllers
{
    [Route("api/product")]
    [ApiController]
    [AllowAnonymous]
    public class ProductController : ControllerBase
    {
        private ProductRepository productRepository;
        public ProductController(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // GET: api/<ProductController>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetProductAll(string? search, double? from, double? to, string? sortBy, int? limit, int? page = 1)
        {
            return Ok(await productRepository.GetAllProduct(search , from , to , sortBy ,limit ,  page));
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            return Ok(await productRepository.GetProductById(id));
        }
        // GET api/<ProductController>/5
        [AllowAnonymous]
        [HttpGet("category/{categoryCode}")]
        public async Task<IActionResult> GetProductByCategory(string categoryCode , string? search, double? from, double? to, string? sortBy, int? limit, int? page = 1)
        {
            return Ok(await productRepository.GetProductByCategory(categoryCode , search, from, to, sortBy, limit, page));
        }
        // POST api/<ProductController>
        [Authorize(Policy = "authenticated")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            await productRepository.AddProduct(product);
            return Ok();
        }

        // PUT api/<ProductController>
        //[Authorize(Policy = "authenticated")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string id, [FromBody] ProductDTO productDTO)
        {
            await productRepository.UpdateProduct(id, productDTO);
            return Ok();
        }
        [Authorize(Policy = "authenticated")]
        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await productRepository.DeleteProduct(id);
            return Ok();
        }
    }
}
