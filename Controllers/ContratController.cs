using collaborateur.Data.DbContexts;
using collaborateur.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace collaborateur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContratController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("liste")]
        public async Task<ActionResult<IEnumerable<Contrat>>> GetContrats()
        {
            var contrats = await _context.contrat.ToListAsync();
            if (contrats == null || !contrats.Any())
            {
                return NotFound("Aucun contrat trouvé.");
            }
            return Ok(contrats);
        }
    }
}