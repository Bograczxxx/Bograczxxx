using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BograczApi.Data;
using BograczApi.Models;

namespace BograczApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _db;
        public UsersController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _db.Users.Include(u => u.Orders).ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }
    }
}
