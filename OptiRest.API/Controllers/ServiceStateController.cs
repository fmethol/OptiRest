using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptiRest.Service.Interfaces;

namespace OptiRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceStateController : ControllerBase
    {
        private readonly IServiceStateService _serviceStateService;

        public ServiceStateController(IServiceStateService serviceStateService)
        {
            _serviceStateService = serviceStateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetServiceStates()
        {
            var serviceStates = await _serviceStateService.GetServiceStates();

            if (serviceStates == null)
            {
                return NotFound();
            }

            return Ok(serviceStates);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceState(int id)
        {
            var serviceState = await _serviceStateService.GetServiceState(id);

            if (serviceState == null)
            {
                return NotFound();
            }

            return Ok(serviceState);
        }
    }
}
