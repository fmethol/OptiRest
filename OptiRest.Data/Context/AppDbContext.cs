using Microsoft.EntityFrameworkCore;
using OptiRest.Data.Models;

namespace OptiRest.Data.Context
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }

        public DbSet<Plato> Platos { get; set; }
    }
}
