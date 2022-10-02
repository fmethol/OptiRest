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
            modelBuilder.Entity<Country>().ToTable("Countries");
            
            modelBuilder.Entity<Country>()
                .HasData(
                    new Country { CountryId = 1, Name = "Argentina" }
                );

            modelBuilder.Entity<State>()
                .HasData(
                    new State { StateId = 1, Name = "Buenos Aires", CountryId = 1 },
                    new State { StateId = 5, Name = "Ciudad Autónoma de Buenos Aires", CountryId = 1 },
                    new State { StateId = 2, Name = "Catamarca", CountryId = 1 },
                    new State { StateId = 3, Name = "Chaco", CountryId = 1 },
                    new State { StateId = 4, Name = "Chubut", CountryId = 1 },
                    new State { StateId = 6, Name = "Córdoba", CountryId = 1 },
                    new State { StateId = 7, Name = "Corrientes", CountryId = 1 },
                    new State { StateId = 8, Name = "Entre Ríos", CountryId = 1 },
                    new State { StateId = 9, Name = "Formosa", CountryId = 1 },
                    new State { StateId = 10, Name = "Jujuy", CountryId = 1 },
                    new State { StateId = 11, Name = "La Pampa", CountryId = 1 },
                    new State { StateId = 12, Name = "La Rioja", CountryId = 1 },
                    new State { StateId = 13, Name = "Mendoza", CountryId = 1 },
                    new State { StateId = 14, Name = "Misiones", CountryId = 1 },
                    new State { StateId = 15, Name = "Neuquén", CountryId = 1 },
                    new State { StateId = 16, Name = "Río Negro", CountryId = 1 },
                    new State { StateId = 17, Name = "Salta", CountryId = 1 },
                    new State { StateId = 18, Name = "San Juan", CountryId = 1 },
                    new State { StateId = 19, Name = "San Luis", CountryId = 1 },
                    new State { StateId = 20, Name = "Santa Cruz", CountryId = 1 },
                    new State { StateId = 21, Name = "Santa Fe", CountryId = 1 },
                    new State { StateId = 22, Name = "Santiago del Estero", CountryId = 1 },
                    new State { StateId = 23, Name = "Tierra del Fuego", CountryId = 1 },
                    new State { StateId = 24, Name = "Tucumán", CountryId = 1 }
                );

            modelBuilder.Entity<City>()
                .HasData(
                    new City { cityId = 1, city = "12 De Agosto", stateId = 1 },
                    new City { cityId = 2, city = "12 De Octubre", stateId = 1 },
                    new City { cityId = 3, city = "16 De Julio", stateId = 1 },
                    new City { cityId = 4, city = "17 De Agosto", stateId = 1 },
                    new City { cityId = 5, city = "20 De Junio", stateId = 1 },
                    new City { cityId = 6, city = "25 De Mayo", stateId = 1 },
                    new City { cityId = 7, city = "30 De Agosto", stateId = 1 },
                    new City { cityId = 8, city = "9 De Abril", stateId = 1 },
                    new City { cityId = 9, city = "9 De Julio", stateId = 1 },
                    new City { cityId = 10, city = "Abasto", stateId = 1 },
                    new City { cityId = 11, city = "Abbott", stateId = 1 },
                    new City { cityId = 12, city = "Abel", stateId = 1 },
                    new City { cityId = 13, city = "Abra De Hinojo", stateId = 1 },
                    new City { cityId = 14, city = "Acassuso", stateId = 1 },
                    new City { cityId = 15, city = "Aceilan", stateId = 1 },
                    new City { cityId = 16, city = "Acevedo", stateId = 1 },
                    new City { cityId = 17, city = "Achupallas", stateId = 1 },
                    new City { cityId = 18, city = "Adela", stateId = 1 },
                    new City { cityId = 19, city = "Adela Corti", stateId = 1 },
                    new City { cityId = 20, city = "Adela Saenz", stateId = 1 },
                    new City { cityId = 21, city = "Adolfo Alsina", stateId = 1 },
                    new City { cityId = 22, city = "Adolfo Gonzalez Chavez", stateId = 1 },
                    new City { cityId = 23, city = "Aeropuerto Ezeiza", stateId = 1 },
                    new City { cityId = 24, city = "Agote", stateId = 1 },
                    new City { cityId = 25, city = "Aguara", stateId = 1 },
                    new City { cityId = 26, city = "Aguas Corrientes", stateId = 1 },
                    new City { cityId = 27, city = "Aguas Verdes", stateId = 1 },
                    new City { cityId = 28, city = "Aguirrezabala", stateId = 1 },
                    new City { cityId = 29, city = "Agustin Mosconi", stateId = 1 },
                    new City { cityId = 30, city = "Agustin Roca", stateId = 1 },
                    new City { cityId = 31, city = "Agustina", stateId = 1 },
                    new City { cityId = 32, city = "Alagon", stateId = 1 },
                    new City { cityId = 33, city = "Alamos", stateId = 1 },
                    new City { cityId = 34, city = "Alastuey", stateId = 1 },
                    new City { cityId = 35, city = "Albariño", stateId = 1 },
                    new City { cityId = 36, city = "Alberdi", stateId = 1 },
                    new City { cityId = 37, city = "Alberti", stateId = 1 },
                    new City { cityId = 38, city = "Aldea Romana", stateId = 1 },
                    new City { cityId = 39, city = "Aldea San Andres", stateId = 1 },
                    new City { cityId = 40, city = "Aldecon", stateId = 1 },
                    new City { cityId = 41, city = "Aldo Bonzi", stateId = 1 },
                    new City { cityId = 42, city = "Alegre", stateId = 1 },
                    new City { cityId = 43, city = "Alejandro Korn", stateId = 1 },
                    new City { cityId = 44, city = "Alejandro Petion", stateId = 1 },
                    new City { cityId = 45, city = "Alfa", stateId = 1 },
                    new City { cityId = 46, city = "Alfalad", stateId = 1 },
                    new City { cityId = 47, city = "Alferez San Martin", stateId = 1 },
                    new City { cityId = 48, city = "Alfredo Demarchi", stateId = 1 },
                    new City { cityId = 49, city = "Algarrobo", stateId = 1 },
                    new City { cityId = 50, city = "Almacen Castro", stateId = 1 }

                );


        }

        public DbSet<Plato> Platos { get; set; }
        public DbSet<TakedRange> TakedRanges { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<BusinessConfig> BusinessConfigs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Area> Areas { get; set; }

    }
}
