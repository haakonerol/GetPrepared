
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Core;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<ProductEntity> _products = new List<ProductEntity>
        {
            new ProductEntity { Id = 1, Name = "Apple", Price = "1000" },
            new ProductEntity { Id = 2, Name = "Samsung", Price = "9000" },
            new ProductEntity { Id = 3, Name = "Huawei", Price = "8000" }
        };

        [HttpGet]
        public async Task<ActionResult<List<ProductEntity>>> Get()
        {
            return Ok(_products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductEntity>> GetById(int id)
        {
            var product = _products.Find(p => p.Id == id);
            if(product == null)
                return BadRequest("Product not found");
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<List<ProductEntity>>> AddProduct(ProductEntity product)
        {
            _products.Add(product);
            return Ok(_products);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ProductEntity>>> UpdateProduct(int id, ProductEntity request)
        {
            var product = _products.Find(p => p.Id == request.Id);
            if(product == null)
                return BadRequest("Product not found to update");
            product.Name = request.Name;
            product.Price = request.Price;
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ProductEntity>>> DeleteProduct(int id)
        {
            var product = _products.Find(p => p.Id == id);
            if(product == null)
                return BadRequest("Product not found to delete");
            _products.Remove(product);
            return Ok(_products);
        }

    }
}