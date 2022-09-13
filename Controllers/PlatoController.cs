using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptiRest.Data;
using OptiRest.Models;
using System.Security.AccessControl;

namespace OptiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatoController : ControllerBase
    {
        private readonly AppDbContext _db;

        public PlatoController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlatos()
        {
            var lista = await _db.Platos.OrderBy(c => c.Nombre).ToListAsync();

            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPlato(int id)
        {
            var plato = await _db.Platos.FirstOrDefaultAsync(c => c.Id == id);

            if(plato == null)
            {
                return NotFound();
            }

            return Ok(plato);
        }

        [HttpPost]
        public async Task<IActionResult> CrearPlato([FromBody] Plato plato)
        {
            if (plato == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _db.AddAsync(plato);
            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarPlato(Plato request)
        {

            var plato = await _db.Platos.FirstOrDefaultAsync(c => c.Id == request.Id);

            if (plato == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            plato.Nombre = request.Nombre;
            plato.Descripcion = request.Descripcion;
            plato.Precio = request.Precio;

            await _db.SaveChangesAsync();

            return Ok(plato);
        }


        
        [HttpDelete]
        public async Task<IActionResult> BorrarPlato(int id)
        {
            var plato = await _db.Platos.FirstOrDefaultAsync(c => c.Id == id);

            if(plato == null)
            {
                return NotFound();
            }

            _db.Platos.Remove(plato);
            await _db.SaveChangesAsync();
            return Ok("Plato Eliminado");
        }
    }
}
