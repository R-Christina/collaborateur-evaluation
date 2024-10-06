using System.ComponentModel.DataAnnotations;

namespace collaborateur.Models
{
    public class Service
    {
        [Key]
        public int service_id { get; set; }
        public string service_nom { get; set; }
    }
}
