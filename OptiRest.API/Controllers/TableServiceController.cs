using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptiRest.Models.Dtos;
using OptiRest.Service.Interfaces;

namespace OptiRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableServiceController : ControllerBase
    {
        private readonly ITableServiceService _tableServiceService;

        public TableServiceController(ITableServiceService tableServiceService)
        {
            _tableServiceService = tableServiceService;
        }

        [HttpGet("byTenant/{tenantId:int}")]
        public async Task<IActionResult> GetTableServices(int tenantId, bool active = true)
        {
            var tableServices = await _tableServiceService.GetTableServices(tenantId, active);
            return Ok(tableServices);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTableService(int id)
        {
            var tableService = await _tableServiceService.GetTableService(id);
            return Ok(tableService);
        }

        [HttpPost]
        public async Task<IActionResult> AddTableService([FromBody] TableServiceDto tableServiceDto)
        {
            if (tableServiceDto == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTableService = await _tableServiceService.AddTableService(tableServiceDto);
            return Ok(newTableService);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTableService(TableServiceDto request)
        {
            if (request == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTableService = await _tableServiceService.UpdateTableService(request);
            return Ok(updatedTableService);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTableService(int id)
        {
            var deletedTableService = await _tableServiceService.DeleteTableService(id);
            return Ok(deletedTableService);
        }
    }
}
