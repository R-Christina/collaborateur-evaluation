using collaborateur.Data.DbContexts;
using collaborateur.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace collaborateur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServiceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("liste")]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            var services = await _context.service.ToListAsync();
            if (services == null || !services.Any())
            {
                return NotFound("Aucun service trouvé.");
            }
            return Ok(services);
        }
    }
} 