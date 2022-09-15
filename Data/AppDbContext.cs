using Microsoft.EntityFrameworkCore;
using OptiRest.Models;

namespace OptiRest.Data
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }

        public DbSet<Plato> Platos { get; set; }
    }
}
