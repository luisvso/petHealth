using PetHealth.Dtos;
using PetHealth.Models;

namespace PetHealth.Mapper
{
    public static class VacinaMapper
    {
        public static Vacina ToEntity(this VacinaDTO dTO)
        {
            return new Vacina
            {
                Nome=dTO.Nome,
                DataAplicacao=dTO.DataAplicacao,
                DuracaoMeses=dTO.DuracaoMeses,
                PetId=dTO.PetId
            };
        }


        public static VacinaDTO ToDto(this Vacina vacina)
        {
            return new VacinaDTO(vacina.Nome, vacina.DataAplicacao, 
            vacina.DuracaoMeses, vacina.PetId);
        }
    }
}