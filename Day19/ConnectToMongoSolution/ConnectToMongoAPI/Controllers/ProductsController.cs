using ConnectToMongoAPI.Interfaces;
using ConnectToMongoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectToMongoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<string, Product> _repository;

        public ProductsController(IRepository<string, Product> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var products = await _repository.GetAllAsync();
            return Ok(products);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Product>> GetById(string id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            var createdProduct = await _repository.CreateAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }
    }
}
