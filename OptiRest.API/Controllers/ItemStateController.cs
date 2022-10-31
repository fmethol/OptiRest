using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptiRest.Service.Interfaces;

namespace OptiRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemStateController : ControllerBase
    {
        private readonly IItemStateService _itemStateService;

        public ItemStateController(IItemStateService itemStateService)
        {
            _itemStateService = itemStateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetItemStates()
        {
            var itemStates = await _itemStateService.GetItemStates();

            if (itemStates == null)
            {
                return NotFound();
            }

            return Ok(itemStates);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemState(int id)
        {
            var itemState = await _itemStateService.GetItemState(id);

            if (itemState == null)
            {
                return NotFound();
            }

            return Ok(itemState);
        }
    }
}
