using collaborateur.Data.DbContexts;
using collaborateur.Models;
using Microsoft.AspNetCore.Mvc;

namespace collaborateur.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Type_empController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _dbContext;

        public Type_empController(IConfiguration configuration, AppDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpGet("liste")]
        public ActionResult<IEnumerable<type_emp>> GetTypeEmps()
        {
            var typeEmps = _dbContext.type_emp.ToList();
            return Ok(typeEmps);
        }
    }
}