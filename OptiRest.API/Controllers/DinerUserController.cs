using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptiRest.Models.Dtos;
using OptiRest.Service.Interfaces;

namespace OptiRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DinerUserController : ControllerBase
    {
        private readonly IDinerUserService _dinerUserService;

        public DinerUserController(IDinerUserService dinerUserService)
        {
            _dinerUserService = dinerUserService;
        }

        [HttpGet("byEmail/{email}")]
        public async Task<IActionResult> GetDinerUsersByEmail(String email)
        {
            var dinerUsers = await _dinerUserService.GetDinerUserByEmail(email);
            return Ok(dinerUsers);
        }

        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetDinerUserById(int id)
        {
            var dinerUser = await _dinerUserService.GetDinerUserById(id);
            return Ok(dinerUser);
        }

        [HttpPost]
        public async Task<IActionResult> AddDinerUser([FromBody] DinerUserDto dinerUserDto)
        {
            if (dinerUserDto == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newDinerUser = await _dinerUserService.AddDinerUser(dinerUserDto);
            return Ok(newDinerUser);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDinerUser(DinerUserDto request)
        {
            if (request == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedDinerUser = await _dinerUserService.UpdateDinerUser(request);
            return Ok(updatedDinerUser);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDinerUser(int id)
        {
            var deletedDinerUser = await _dinerUserService.DeleteDinerUser(id);
            return Ok(deletedDinerUser);
        }
    }
}
