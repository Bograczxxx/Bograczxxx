using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BograczApi.Data;
using BograczApi.Models;

namespace BograczApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ProductsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _db.Products.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }
    }
}
