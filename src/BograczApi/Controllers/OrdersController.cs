using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BograczApi.Data;
using BograczApi.Models;

namespace BograczApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _db;
        public OrdersController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await _db.Orders.Include(o => o.Product).Include(o => o.User).ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Order order)
        {
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }
    }
}
