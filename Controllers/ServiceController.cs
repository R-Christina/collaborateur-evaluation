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

        [HttpPost("ajouter")]
        public async Task<IActionResult> PostService([FromBody] Service service)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.service.Add(service);
                    await _context.SaveChangesAsync(); 
                    return Ok(new { message = "Service inséré avec succès", data = service });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { message = "Erreur lors de l'insertion", error = ex.Message });
                }
            }
            return BadRequest(ModelState);
        }
    }
} 