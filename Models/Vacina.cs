using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PetHealth.Models
{
    public class Vacina
    {
        
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataAplicacao { get; set; }
        public int DuracaoMeses { get; set; }
        public int PetId { get; set; }

        [JsonIgnore] 
        public virtual Pet? Pet { get; set; }

        public DateTime ProximaDose => DataAplicacao.AddMonths(DuracaoMeses);
        public bool EstaVencida => DateTime.Now > ProximaDose;
        public bool EstaProxima => DateTime.Now >= ProximaDose.AddDays(-7) && DateTime.Now <= ProximaDose;
        
    }
}