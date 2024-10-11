namespace collaborateur.ViewModels
{
    public class EmpViewModel
    {
        public required int EmpId { get; set; }   
        public required int Matricule { get; set; } 
        public required string EmpNom { get; set; }     
        public required string EmpPrenom { get; set; }   
        public required DateTime DateNaissance { get; set; } 
        public required string GenreNom { get; set; }    
        public required string DeptNom { get; set; }
        public required string DirNom { get; set; }
        public required string ServiceNom { get; set; }   
        public required string PosteNom { get; set; }
        public string? SupérieurNom { get; set; }
    }
}