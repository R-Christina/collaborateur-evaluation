using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace collaborateur.Models
{
    public class Users
    {
        [Key]
        public int user_id { get; set; }

        [ForeignKey("emp")]
        public int? emp_id { get; set; } 
        public required int matricule { get; set; }
        public required string email { get;set; }
        public required string password { get; set; }
        public required int role_id { get; set ;}

        public string? resetToken { get; set; }
        public DateTime? resetTokenExpiration { get; set; }

        public Emp? emp { get; set; }
    }
}