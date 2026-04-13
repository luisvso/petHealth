using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetHealth.Data;
using PetHealth.Dtos;
using PetHealth.Mapper;
using PetHealth.Models;

namespace PetHealth.Controllers
{
    [ApiController]
    [Route("api/pets")]
    public class PetController : ControllerBase
    {
       private readonly AppDbContext _appDbContext; 
       

       public PetController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddPet(PetDTO petDTO)
        {
            var petResult = petDTO.ToEntity();
            _appDbContext.Pets.Add(petResult);
            await _appDbContext.SaveChangesAsync();

            return Ok(petResult.ToDto());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            var petResult = await _appDbContext.Pets.Include(p => p.Vacinas).ToListAsync();

            return Ok(petResult);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
            var pet = await _appDbContext.Pets.FindAsync(id);

            if(pet == null)
            {
                return NotFound("The pet was not found");
            }
            return Ok(pet);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePet(int id, [FromBody] PetDTO petAtualizado)
        {

            var pet = await _appDbContext.Pets.FindAsync(id);

            if(pet == null)
            {
                return NotFound("The pet was not found");
            }

            _appDbContext.Entry(pet).CurrentValues.SetValues(petAtualizado.ToEntity());

            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, pet);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePet(int id)
        {

            var pet = await _appDbContext.Pets.FindAsync(id);

            if(pet == null)
            {
                return NotFound("The pet was not found");
            }

            _appDbContext.Pets.Remove(pet);

            await _appDbContext.SaveChangesAsync();

            return Ok("Pet Deletado com Sucesso!");

        }


        [HttpGet("vacinas/{id}")]
        public async Task<ActionResult> getPetVacinaAplicada(int id)
        {
            var queryResult = await _appDbContext.Vacinas.Where(v => v.PetId==id)
            .OrderByDescending( v => v.DataAplicacao).ToListAsync();

            if(queryResult == null || queryResult.Count == 0)
            {
               return NotFound("Este animal não tem vacinas cadastradas");
            }
            
            var listaDto = queryResult.Select(v => v.ToDto()).ToList();

            return Ok(listaDto);

        }


    }

}