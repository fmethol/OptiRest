using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptiRest.Service.Interfaces;

namespace OptiRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableShapeController : ControllerBase
    {
        private readonly ITableShapeService _tableShapeService;

        public TableShapeController(ITableShapeService tableShapeService)
        {
            _tableShapeService = tableShapeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTableShapes()
        {
            var tableShapes = await _tableShapeService.GetTableShapes();
            return Ok(tableShapes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTableShape(int id)
        {
            var tableShape = await _tableShapeService.GetTableShape(id);
            return Ok(tableShape);
        }


    }
}
