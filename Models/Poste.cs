using System.ComponentModel.DataAnnotations;

namespace collaborateur.Models
{
    public class Poste
    {
        [Key]
        public int poste_id { get; set; }
        public string poste_nom { get; set; }
    }
}
