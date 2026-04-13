using PetHealth.Dtos;
using PetHealth.Models;

namespace PetHealth.Mapper
{
    public static class PetMapper
    {
        public static Pet ToEntity(this PetDTO dto)
        {
            return new Pet
            {
                Id = dto.Id,
                Nome = dto.Nome,
                Especie = dto.Especie,
                Raca = dto.Raca,
                EmailTutor = dto.EmailTutor
            };
        }


        public static PetDTO ToDto(this Pet pet)
        {
            return new PetDTO(pet.Id, pet.Nome, pet.Especie, pet.Raca, pet.EmailTutor);
        }
    }
}