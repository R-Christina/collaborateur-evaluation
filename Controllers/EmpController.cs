using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using collaborateur.Models;
using collaborateur.Data.DbContexts;
using collaborateur.ViewModels;

namespace collaborateur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmpController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("liste")] // Endpoint pour récupérer les employés
        public async Task<ActionResult<IEnumerable<EmpViewModel>>> GetAllEmp()
        {
            var emp = await _context.emp
                .Include(e => e.genre) 
                .Include(e => e.dir) 
                .Include(e => e.dept)
                .Include(e => e.service) 
                .Include(e => e.emp_sup)
                .Select(e => new EmpViewModel
                {
                    EmpId = e.emp_id,
                    Matricule = e.users != null ? e.users.matricule : 0, // Handle possible null
                    EmpNom = e.emp_nom ?? "Inconnu", // Default value if null
                    EmpPrenom = e.emp_prenom ?? "Inconnu", // Default value if null
                    DateNaissance = e.date_naissance,
                    GenreNom = e.genre != null ? e.genre.genre_nom : "Inconnu", // Handle possible null
                    DeptNom = e.dept != null ? e.dept.dept_nom : "Inconnu", // Handle possible null
                    DirNom = e.dir != null ? e.dir.dir_nom : "Inconnu", // Handle possible null
                    PosteNom = e.poste_nom != null ? e.poste_nom : "Inconnu", // Handle possible null
                    ServiceNom = e.service != null ? e.service.service_nom : "Inconnu", // Handle possible null
                    SupérieurNom = e.emp_sup != null ? e.emp_sup.emp_nom + " " + e.emp_sup.emp_prenom : "Aucun" 
                })
                .ToListAsync();

            return Ok(emp); 
        }

        [HttpPost("ajouter")]
        public async Task<ActionResult> InsertEmp([FromBody] InsertEmpRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                
                _context.emp.Add(request.Emp);
                await _context.SaveChangesAsync(); 

                
                Users newUser = new()
                {
                    emp_id = request.Emp.emp_id,  
                    matricule = request.User.matricule,
                    email = request.User.email,
                    password = request.User.password,
                    role_id = request.User.role_id 
                };

                // Ajouter l'utilisateur
                _context.users.Add(newUser);
                await _context.SaveChangesAsync();

                return Ok(new { message = "L'employé et l'utilisateur ont été ajoutés avec succès.", empId = request.Emp.emp_id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur serveur : {ex.Message}");
            }
        }

    }
}
