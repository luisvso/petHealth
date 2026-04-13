using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetHealth.Data;
using PetHealth.Dtos;
using PetHealth.Mapper;
using PetHealth.Models;

namespace PetHealth.Controllers
{
    [ApiController]
    [Route("api/vacina")]
    public class VacinaController : ControllerBase
    {

        private readonly AppDbContext _context;

        public VacinaController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        

        [HttpPost]
        public async Task<IActionResult> AddVacina(VacinaDTO vacinaDTO)
        {
            var pet = await _context.Pets.FindAsync(vacinaDTO.PetId);
            if (pet == null) return NotFound($"Pet com id {vacinaDTO.PetId} não encontrado.");
            var vacinaResult = vacinaDTO.ToEntity();
            _context.Vacinas.Add(vacinaResult);
            await _context.SaveChangesAsync();

            return Ok(vacinaResult.ToDto());

        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacina>>> GetVacinas()
        {
            var vacinaResult = await _context.Vacinas.ToListAsync();

            return Ok(vacinaResult);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Vacina>>> GetVacina(int id)
        {
            var vacinaResult = await _context.Vacinas.FindAsync(id);


            if(vacinaResult == null)
            {
                return NotFound("A vacina não foi achada");
                
            }

            return Ok(vacinaResult);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVacina(int id, [FromBody] VacinaDTO vacinaDTO)
        {
            var vac = await _context.Vacinas.FindAsync(id);


            if(vac == null)
            {
                return NotFound("A vacina não foi achada");
            }

            _context.Entry(vac).CurrentValues.SetValues(vacinaDTO.ToEntity());
            await _context.SaveChangesAsync();


            return StatusCode(201, vac);

        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVacina(int id)
        {
            var vac = await _context.Vacinas.FindAsync(id);

            if(vac == null)
            {
                return NotFound("Vacina não foi encontrada");
            }

            _context.Vacinas.Remove(vac);

            await _context.SaveChangesAsync();

            return Ok("Vacina deletada com sucesso");
        }

        [HttpGet("alertas")]
        public async Task<ActionResult> GetAlertas()
        {
            var hoje = DateTime.UtcNow;
            var daqui30Dias = hoje.AddDays(30);

            var alertas = await _context.Vacinas
                .Include(v => v.Pet)
                .ToListAsync(); 

            var filtrados = alertas.Where(v => v.ProximaDose >= hoje && v.ProximaDose <= daqui30Dias)
                                .Select(v => new {
                                    Pet = v.Pet?.Nome,
                                    Email = v.Pet?.EmailTutor,
                                    Vacina = v.Nome,
                                    Vencimento = v.ProximaDose
                                });

            return Ok(filtrados);
        }
    }
}