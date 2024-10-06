using System.ComponentModel.DataAnnotations;

namespace collaborateur.Models
{
    public class Cp
    {
        [Key]
        public int cp_id { get; set; }
        public string cp_nom { get; set; }
    }
}
