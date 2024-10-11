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

        [HttpPost("ajouter")]
        public async Task<IActionResult> PostDir([FromBody] Dir dir)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.dir.Add(dir);
                    await _context.SaveChangesAsync(); 
                    return Ok(new { message = "Direction inséré avec succès", data = dir });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { message = "Erreur lors de l'insertion", error = ex.Message });
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("supprimer/{id}")]
        public async Task<IActionResult> DeleteDir(int id)
        {
            try
            {
                // Rechercher la direction par son ID
                var dir = await _context.dir.FindAsync(id);
                
                if (dir == null)
                {
                    return NotFound(new { message = "Direction non trouvée." });
                }

                // Supprimer la direction
                _context.dir.Remove(dir);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Direction supprimée avec succès." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erreur lors de la suppression", error = ex.Message });
            }
        }
    }
}