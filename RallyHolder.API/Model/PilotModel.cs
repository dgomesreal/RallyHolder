using System.ComponentModel.DataAnnotations;

namespace RallyHolder.API.Model
{
    public class PilotModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is mandatory")]
        [MinLength(5, ErrorMessage = "Name must be longer then 5 characters")]
        [MaxLength(50, ErrorMessage = "Name cannot be longer then 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is mandatory")]
        [MinLength(5, ErrorMessage = "Surname must be longer then 5 characters")]
        [MaxLength(50, ErrorMessage = "Surname cannot be longer then 50 characters")]
        public string Surname { get; set; }
        public int TeamId { get; set; }

        //public string NomeCompleto { 
        //    get { return Nome + " " + SobreNome; } 
        //}
        public string FullName
        {
            get { return $"{Name} {Surname}"; }    
        }   
    }
}
