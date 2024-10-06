using collaborateur.Data.DbContexts;
using collaborateur.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace collaborateur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Type_heureController : ControllerBase
    {
        private readonly AppDbContext _context;

        public Type_heureController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("liste")]
        public async Task<ActionResult<IEnumerable<Type_heure>>> GetType_heures()
        {
            var type_heures = await _context.type_heure.ToListAsync();
            if (type_heures == null || !type_heures.Any())
            {
                return NotFound("Aucun type_heure trouvé.");
            }
            return Ok(type_heures);
        }
    }
} 