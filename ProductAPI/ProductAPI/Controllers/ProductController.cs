using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Core;

namespace ProductAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ProductController : Controller
{
    // GET
    [HttpGet]
    public IActionResult Get()
    {
        var products = new List<ProductEntity>
        {
            new ProductEntity { Id = 1, Name = "Apple", Price = "100" }
        };
        return View(products);
    }
}