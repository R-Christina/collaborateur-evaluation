using System.ComponentModel.DataAnnotations;

namespace collaborateur.Models
{
    public class Site
    {
        [Key]
        public int site_id { get; set; }
        public string site_nom { get; set; }
    }
}
