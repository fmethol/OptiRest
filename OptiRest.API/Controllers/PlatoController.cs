using Microsoft.AspNetCore.Mvc;
using OptiRest.Models.Dtos;
using OptiRest.Service.Interfaces;

namespace OptiRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatoController : ControllerBase
    {
        private readonly IPlatoService _platoService;

        public PlatoController(IPlatoService platoService)
        {
            _platoService = platoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlatos()
        {
            var lista = await _platoService.GetPlatos();

            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPlato(int id)
        {
            var plato = await _platoService.GetPlato(id);

            if(plato == null)
            {
                return NotFound();
            }

            return Ok(plato);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlato([FromBody] PlatoDto plato)
        {
            if (plato == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdPlato = await _platoService.CreatePlato(plato);

            return Ok(createdPlato);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlato(PlatoDto request)
        {

            var plato = await _platoService.UpdatePlato(request);

            return Ok(plato);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePlato(int id)
        {
            var resultId = _platoService.DeletePlato(id);

            return Ok(resultId);
        }
    }
}