using System.ComponentModel.DataAnnotations;

namespace collaborateur.Models
{
    public class Type_heure
    {
        [Key]
        public int type_heure_id { get; set; }
        public required string type_heure_nom { get; set; }
    }
}
