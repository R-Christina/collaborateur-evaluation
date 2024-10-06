using collaborateur.Data.DbContexts;
using collaborateur.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace collaborateur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class siteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public siteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("liste")]
        public async Task<ActionResult<IEnumerable<Site>>> GetSites()
        {
            var siteSites = await _context.site.ToListAsync();
            if (siteSites == null || !siteSites.Any())
            {
                return NotFound("Aucun site section trouvé.");
            }
            return Ok(siteSites);
        }
    }
}