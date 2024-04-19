using BrochureAPI.Data;
using BrochureAPI.Dtos.Service;
using BrochureAPI.Helpers;
using BrochureAPI.Interfaces;
using BrochureAPI.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrochureAPI.Controllers
{
    [Route("api/services")]
    [ApiController]

    public class ServicesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IServices _services;
        public ServicesController(ApplicationDBContext context , IServices services)
        {
            _context = context;
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDataAsync([FromQuery] QueryObject query)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var services = await _services.GetAll(query);
            var service = services.Select(s => s.ToServicesDto());
            return Ok(service);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetService([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service =  await _services.GetService(id);

            if(service == null)
            {
                return NotFound();
            }

            return Ok(service.ToServicesDto()) ;

        }

        [HttpPost]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceDto serviceDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = serviceDto.ToServices();
            var serviceModel = await _services.CreateService(service);
            return CreatedAtAction(nameof(GetService) , new { id = service.Id } , service.ToServicesDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateService([FromRoute] int id , [FromBody] UpdateServiceDto updateService)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = await _services.UpdateService(id, updateService);
            if(service == null)
            {
                return NotFound();
            }
            return Ok(service);


        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteService([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _services.DeleteService(id);

            
            return Ok("Service Deleted!");

        }
    }
}
