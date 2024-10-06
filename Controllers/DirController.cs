using collaborateur.Data.DbContexts;
using collaborateur.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace collaborateur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DirController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("liste")]
        public async Task<ActionResult<IEnumerable<Dir>>> GetDirs()
        {
            var dirs = await _context.dir.ToListAsync();
            if (dirs == null || !dirs.Any())
            {
                return NotFound("Aucun direction trouvé.");
            }
            return Ok(dirs);
        }
    }
}