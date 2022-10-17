using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptiRest.Service.Interfaces;

namespace OptiRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableStateController : ControllerBase
    {
        private readonly ITableStateService _tableStateService;

        public TableStateController(ITableStateService tableStateService)
        {
            _tableStateService = tableStateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTableStates()
        {
            var tableStates = await _tableStateService.GetTableStates();
            return Ok(tableStates);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTableState(int id)
        {
            var tableState = await _tableStateService.GetTableState(id);
            return Ok(tableState);
        }
    }
}
