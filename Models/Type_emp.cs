using System.ComponentModel.DataAnnotations;

namespace collaborateur.Models
{
    public class Type_emp
    {
        [Key]
        public int type_emp_id { get; set; }
        public required string type_emp_nom { get; set; }
    }
}