using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptiRest.Models.Dtos;
using OptiRest.Service.Interfaces;

namespace OptiRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTables()
        {
            var tables = await _tableService.GetTables();
            return Ok(tables);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTable(int id)
        {
            var table = await _tableService.GetTable(id);
            return Ok(table);
        }

        [HttpPost]
        public async Task<IActionResult> AddTable([FromBody] TableDto tableDto)
        {
            if (tableDto == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTable = await _tableService.AddTable(tableDto);
            return Ok(newTable);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTable(TableDto request)
        {
            if (request == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTable = await _tableService.UpdateTable(request);
            return Ok(updatedTable);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            var deletedTable = await _tableService.DeleteTable(id);
                       
            return Ok(deletedTable);
        }
    }
}
