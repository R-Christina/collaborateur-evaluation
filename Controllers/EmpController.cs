using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using collaborateur.Models;
using collaborateur.Data.DbContexts;
using collaborateur.ViewModels; // Assurez-vous d'importer le namespace des ViewModels

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
                .Include(e => e.poste) 
                .Include(e => e.service) 
                .Include(e => e.emp_sup) 
                .Include(e => e.users)
                .Select(e => new EmpViewModel
                {
                    EmpId = e.emp_id,
                    Matricule = e.users.matricule,
                    EmpNom = e.emp_nom,
                    EmpPrenom = e.emp_prenom,
                    DateNaissance = e.date_naissance,
                    GenreNom = e.genre.genre_nom, 
                    DeptNom = e.dept.dept_nom,
                    DirNom = e.dir.dir_nom,
                    PosteNom = e.poste.poste_nom, 
                    ServiceNom = e.service.service_nom, 
                    SupérieurNom = e.emp_sup != null ? e.emp_sup.emp_nom + " " + e.emp_sup.emp_prenom : "Aucun" 
                })
                .ToListAsync();

            return Ok(emp); 
        }
    }
}
