

using System.ComponentModel.DataAnnotations;

namespace PetHealth.Models
{
    public class Pet
    {

        public int Id {get; set;} 
        public string Nome {get; set;} = string.Empty;
        public string Especie {get;set;} = string.Empty;
        public string Raca {get;set;} = string.Empty;
        public ICollection<Vacina> Vacinas {get;set;} = new List<Vacina>();
        
        [Required]
        public string EmailTutor {get;set;} = string.Empty;

    }
}