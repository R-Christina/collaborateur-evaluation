using System.ComponentModel.DataAnnotations;

namespace collaborateur.Models
{
    public class Contrat
    {
        [Key]
        public int contrat_id { get; set; }
        public required string type_contrat { get; set; }
    }
}
