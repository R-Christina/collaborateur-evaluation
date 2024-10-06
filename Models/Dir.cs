using System.ComponentModel.DataAnnotations;

namespace collaborateur.Models
{
    public class Dir
    {
        [Key]
        public int dir_id { get; set; }
        public required string dir_nom { get; set; }
    }
}