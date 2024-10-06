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
        public DbSet<type_emp> type_emp {get; set;}
        public DbSet<Cp> cp {get; set;}
        public DbSet<Type_heure> type_heure {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emp>()
                .HasOne(e => e.genre)
                .WithMany() // ou .WithMany(g => g.Emps) si vous avez une collection dans Genre
                .HasForeignKey(e => e.genre_id);

            modelBuilder.Entity<Emp>()
                .HasOne(e => e.poste)
                .WithMany()
                .HasForeignKey(e => e.poste_id);

            modelBuilder.Entity<Emp>()
                .HasOne(e => e.service)
                .WithMany()
                .HasForeignKey(e => e.service_id);

            modelBuilder.Entity<Emp>()
                .HasOne(e => e.dept)
                .WithMany()
                .HasForeignKey(e => e.dept_id);

            modelBuilder.Entity<Emp>()
                .HasOne(e => e.dir)
                .WithMany()
                .HasForeignKey(e => e.dir_id);

            modelBuilder.Entity<Emp>()
                .HasOne(e => e.emp_sup)
                .WithMany()
                .HasForeignKey(e => e.emp_id_sup); // Référence au supérieur

            modelBuilder.Entity<Emp>()
                .HasOne(e => e.users) // Une instance de Users
                .WithOne(u => u.emp)  // Une instance de Emp
                .HasForeignKey<Users>(u => u.emp_id);
        }
    }
}