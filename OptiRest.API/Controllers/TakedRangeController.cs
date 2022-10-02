using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptiRest.Models.Dtos;
using OptiRest.Service.Interfaces;

namespace OptiRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakedRangeController : ControllerBase
    {
        private readonly ITakedRangeService _takedRangeService;

        public TakedRangeController(ITakedRangeService takedRangeService)
        {
            _takedRangeService = takedRangeService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetTakedRanges()
        {
            var lista = await _takedRangeService.GetTakedRanges();

            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTakedRange(int id)
        {
            var takedRange = await _takedRangeService.GetTakedRange(id);

            if (takedRange == null)
            {
                return NotFound();
            }

            return Ok(takedRange);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTakedRange([FromBody] TakedRangeDto takedRange)
        {
            if (takedRange == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTakedRange = await _takedRangeService.CreateTakedRange(takedRange);

            return Ok(createdTakedRange);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTakedRange(TakedRangeDto request)
        {
            if (request == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTakedRange = await _takedRangeService.UpdateTakedRange(request);

            return Ok(updatedTakedRange);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTakedRange(int id)
        {
            var deletedTakedRange = await _takedRangeService.DeleteTakedRange(id);

            return Ok(deletedTakedRange);
        }






    }
}
