using System.ComponentModel.DataAnnotations;
using collaborateur.Models;

namespace collaborateur.ViewModels
{
    public class InsertEmpRequest
    {
        public required Emp Emp { get; set; }
        public required Users User { get; set; }
    }
}