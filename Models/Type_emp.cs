using System.ComponentModel.DataAnnotations;

namespace collaborateur.Models
{
    public class type_emp
    {
        [Key]
        public int type_emp_id { get; set; }
        public string type_emp_nom { get; set; }
    }
}