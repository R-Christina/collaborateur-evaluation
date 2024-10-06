using System.ComponentModel.DataAnnotations;

namespace collaborateur.Models
{
    public class Dept
    {
        [Key]
        public int dept_id { get; set; }
        public string dept_nom { get; set; }
    }
}
