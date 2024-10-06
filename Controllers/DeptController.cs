using collaborateur.Data.DbContexts;
using collaborateur.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace collaborateur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeptController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DeptController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("liste")]
        public async Task<ActionResult<IEnumerable<Dept>>> GetDepts()
        {
            var depts = await _context.dept.ToListAsync();
            if (depts == null || !depts.Any())
            {
                return NotFound("Aucun departement trouvé.");
            }
            return Ok(depts);
        }
    }
}