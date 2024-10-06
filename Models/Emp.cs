using System.ComponentModel.DataAnnotations;

namespace collaborateur.Models
{
    public class Emp
    {
        [Key]
        public int emp_id { get; set; }
        public string emp_nom { get; set; }
        public string emp_prenom { get; set; }
        public DateTime date_naissance { get; set; }
        public int genre_id { get; set; }
        public DateTime date_embauche { get; set; }
        public int poste_id { get; set; }
        public int service_id { get; set; }
        public int dept_id { get; set; }
        public int dir_id { get; set; }
        public int type_heure_id { get; set; }
        public int contrat_id { get; set; }
        public int site_id { get; set; }
        public int cp_id { get; set; }
        public int type_emp_id { get; set; }
        public int? emp_id_sup { get; set; } 

        public virtual Genre genre { get; set; }
        public virtual Poste poste { get; set; }
        public virtual Service service { get; set; }
        public virtual Dept dept { get; set; }
        public virtual Dir dir { get; set; }
        public virtual Type_heure type_heure { get; set; }
        public virtual Contrat contrat { get; set; }
        public virtual Site site { get; set; }
        public virtual Cp cp { get; set; }
        public virtual type_emp type_emp { get; set; }
        public virtual Emp emp_sup { get; set; } 
        public virtual Users users { get; set; }
    }
}
