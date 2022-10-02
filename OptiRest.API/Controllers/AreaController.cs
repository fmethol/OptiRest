using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptiRest.Models.Dtos;
using OptiRest.Service.Interfaces;

namespace OptiRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;

        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpPost]
        public async Task<IActionResult> AddArea([FromBody] AreaDto areaDto)
        {
            if (areaDto == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdArea = await _areaService.AddArea(areaDto);

            return Ok(createdArea);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteArea(int id)
        {
            var deletedArea = await _areaService.DeleteArea(id);

            return Ok(deletedArea);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetArea(int id)
        {
            var area = await _areaService.GetArea(id);

            if (area == null)
            {
                return NotFound();
            }

            return Ok(area);
        }

        [HttpGet]
        public async Task<IActionResult> GetAreas(int tenantId)
        {
            var lista = await _areaService.GetAreas(tenantId);

            return Ok(lista);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateArea(AreaDto request)
        {
            if (request == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedArea = await _areaService.UpdateArea(request);

            return Ok(updatedArea);
        }



    }
}
