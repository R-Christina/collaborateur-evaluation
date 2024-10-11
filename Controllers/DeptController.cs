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

        [HttpPost("ajouter")]
        public async Task<IActionResult> PostDept([FromBody] Dept dept)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.dept.Add(dept);
                    await _context.SaveChangesAsync(); 
                    return Ok(new { message = "Département inséré avec succès", data = dept });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { message = "Erreur lors de l'insertion", error = ex.Message });
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("supprimer/{id}")]
        public async Task<IActionResult> DeleteDept(int id)
        {
            try
            {
                // Rechercher la deptection par son ID
                var dept = await _context.dept.FindAsync(id);
                
                if (dept == null)
                {
                    return NotFound(new { message = "Deptection non trouvée." });
                }

                // Supprimer la deptection
                _context.dept.Remove(dept);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Departement supprimée avec succès." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erreur lors de la suppression", error = ex.Message });
            }
        }
    }
}