using EmptyProject.DTO;
using EmptyProject.Models;
using EmptyProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
        public ActionResult Post([FromBody] CreateShoeDTO shoeDTO)
        {
            Product? product;
            if (shoeDTO == null)
                return NotFound();
            if (shoeDTO.Type.ToLower() == "shoe")
            {
                product = JsonSerializer.Deserialize<Product>(shoeDTO.Data.GetRawText());
                ProductService.AddProduct(product);
                return CreatedAtAction(nameof(Get), new { id = product.Id, product });
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            ProductService.UpdateProduct(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id, product });

        }
    }
}
