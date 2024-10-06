using collaborateur.Data.DbContexts;
using collaborateur.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace collaborateur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CpController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("liste")]
        public async Task<ActionResult<IEnumerable<Cp>>> GetCps()
        {
            var cps = await _context.cp.ToListAsync();
            if (cps == null || !cps.Any())
            {
                return NotFound("Aucun departement trouvé.");
            }
            return Ok(cps);
        }
    }
}