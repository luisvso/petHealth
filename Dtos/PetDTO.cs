using PetHealth.Models;

namespace PetHealth.Dtos
{
    public record PetDTO(
        int Id,
        string Nome,
        string Especie,
        string Raca,
        string EmailTutor
    );
}