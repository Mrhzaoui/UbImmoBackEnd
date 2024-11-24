using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UBEE.Models;
using UBEE.Services;

namespace UBEE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            var services = await _serviceService.GetAllServices();
            return Ok(services);
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost]
        public async Task<IActionResult> CreateService(ServiceCreateDto model)
        {
            var result = await _serviceService.CreateService(model);
            if (result.Succeeded)
            {
                return CreatedAtAction(nameof(GetService), new { id = result.ServiceId }, result);
            }
            return BadRequest(result.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var service = await _serviceService.GetServiceById(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

        // Add more endpoints for updating, deleting, and purchasing services
    }
}

