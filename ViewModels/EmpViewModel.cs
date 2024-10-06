namespace collaborateur.ViewModels
{
    public class EmpViewModel
    {
        public int EmpId { get; set; }   
        public int Matricule { get; set; } 
        public string EmpNom { get; set; }     
        public string EmpPrenom { get; set; }   
        public DateTime DateNaissance { get; set; } 
        public string GenreNom { get; set; }    
        public string DeptNom { get; set; }
        public string DirNom { get; set; }
        public string ServiceNom { get; set; }   
        public string PosteNom { get; set; }     
        public string SupérieurNom { get; set; } 
    }
}
