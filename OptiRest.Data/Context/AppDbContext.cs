using Microsoft.EntityFrameworkCore;
using OptiRest.Data.Models;

namespace OptiRest.Data.Context
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
        public DbSet<TakedRange> TakedRanges { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<BusinessConfig> BusinessConfigs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TableShape> TableShapes{ get; set; }
        public DbSet<TableState> TableStates{ get; set; }
        public DbSet<ServiceState> ServiceStates{ get; set; }
        public DbSet<TableService> TableServices{ get; set; }
        public DbSet<DinerUser> DinerUsers { get; set; }
        public DbSet<ServiceItemState> ServiceItemStates{ get; set; }
        public DbSet<TableService2Item> TableService2Items { get; set; }
        public DbSet<Kitchen> Kitchens { get; set; }
    }
}
