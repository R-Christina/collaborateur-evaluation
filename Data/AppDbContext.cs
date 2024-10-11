using collaborateur.Models;
using Microsoft.EntityFrameworkCore;

namespace collaborateur.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Emp> emp { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Dir> dir {get; set;}
        public DbSet<Dept> dept {get; set;}
        public DbSet<Contrat> contrat {get; set;}
        public DbSet<Service> service {get; set;}
        public DbSet<Site> site {get; set;}
        public DbSet<Type_emp> type_emp {get; set;}
        public DbSet<Type_heure> type_heure {get; set;}
    }
}