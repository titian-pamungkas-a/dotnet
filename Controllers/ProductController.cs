using EmptyProject.Models;
using EmptyProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmptyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return ProductService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            Product product = ProductService.GetProduct(id);
            if (product == null)
                return NotFound();
            return product;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            ProductService.AddProduct(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id, product});
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            ProductService.UpdateProduct(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id, product });

        }
    }
}
