using System.ComponentModel.DataAnnotations;

namespace collaborateur.Models
{
    public class Genre
    {
        [Key]
        public int genre_id { get; set; }
        public required string genre_nom { get; set; }
    }
}
