using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace collaborateur.Models
{
    public class Emp
    {
        [Key]
        public int emp_id { get; set; }
        public string emp_nom { get; set; }
        public string emp_prenom { get; set; }
        public DateTime date_naissance { get; set; }

        [ForeignKey("genre")]
        public int genre_id { get; set; }
        public DateTime date_embauche {get; set;}
        public string poste_nom { get; set; }

        [ForeignKey("service")]
        public int service_id { get; set; }

        [ForeignKey("dept")]
        public int dept_id { get; set; }

        [ForeignKey("dir")]
        public int dir_id { get; set; }    

        [ForeignKey("type_heure")]
        public int type_heure_id { get; set; } 

        [ForeignKey("contrat")]
        public int contrat_id { get; set; }

        [ForeignKey("site")]
        public int site_id { get; set; }

        [ForeignKey("type_emp")]
        public int type_emp_id { get; set; }

        [ForeignKey("emp_sup")]
        public int? emp_id_sup { get; set; } 

        public Genre? genre { get; set; }
        public Service? service { get; set; }
        public Dept? dept { get; set; }
        public Dir? dir { get; set; }
        public Type_heure? type_heure { get; set; }
        public Contrat? contrat { get; set; }
        public Site? site { get; set; }
        public Type_emp? type_emp { get; set; }
        public Emp? emp_sup { get; set; }

        public Users? users { get; set; }
    }
}
