using Microsoft.EntityFrameworkCore;
using PetHealth.Models;

namespace PetHealth.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options){}

        public DbSet<Pet> Pets{get;set;}
        public DbSet<Vacina> Vacinas {get;set;}

         internal async Task FindAsync(int id)
         {
             throw new NotImplementedException();
         }



    }
}