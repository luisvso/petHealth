namespace PetHealth.Dtos
{
    public record VacinaDTO(
        string Nome,
        DateTime DataAplicacao,
        int DuracaoMeses,
        int PetId
    );
}