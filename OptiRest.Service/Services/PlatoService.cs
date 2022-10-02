using Microsoft.EntityFrameworkCore;
using OptiRest.Data.Context;
using OptiRest.Data.Models;
using OptiRest.Models.Dtos;
using OptiRest.Service.Interfaces;

namespace OptiRest.Service.Services
{
    public class PlatoService : IPlatoService
    {
        private readonly AppDbContext _db;

        public PlatoService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<PlatoDto>> GetPlatos()
        {
            var platos = await _db.Platos
                .Select(p => new PlatoDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio
                })
                .ToListAsync();

            return platos;
        }

        public async Task<PlatoDto> GetPlato(int id)
        {
            var plato = _db.Platos.FirstOrDefault(p => p.Id == id);

            if (plato == null)
            {
                return null;
            }

            var platoDto = new PlatoDto
            {
                Id = plato.Id,
                Nombre = plato.Nombre,
                Descripcion = plato.Descripcion,
                Precio = plato.Precio
            };

            return await Task.FromResult(platoDto);
        }

        public async Task<PlatoDto> CreatePlato(PlatoDto platoDto)
        {
            if (platoDto == null)
            {
                return null;
            }

            var plato = new Plato
            {
                Id = platoDto.Id,
                Nombre = platoDto.Nombre,
                Descripcion = platoDto.Descripcion,
                Precio = platoDto.Precio
            };

            await _db.AddAsync(plato);
            await _db.SaveChangesAsync();

            platoDto.Id = plato.Id;

            return platoDto;
        }

        public async Task<PlatoDto> UpdatePlato(PlatoDto request)
        {
            var plato = await _db.Platos.FirstOrDefaultAsync(c => c.Id == request.Id);

            if (plato == null)
            {
                return null;
            }

            plato.Nombre = request.Nombre;
            plato.Descripcion = request.Descripcion;
            plato.Precio = request.Precio;

            await _db.SaveChangesAsync();

            //var platoDto = new PlatoDto
            //{
            //    Id = plato.Id,
            //    Nombre = plato.Nombre,
            //    Descripcion = plato.Descripcion,
            //    Precio = plato.Precio
            //};

            return request;
        }

        public async Task<int> DeletePlato(int id)
        {
            var plato = await _db.Platos.FirstOrDefaultAsync(c => c.Id == id);

            if (plato == null)
            {
                return 0;
            }

            _db.Platos.Remove(plato);
            await _db.SaveChangesAsync();

            return plato.Id;
        }
    }
}
