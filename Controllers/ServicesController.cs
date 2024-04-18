using BrochureAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrochureAPI.Controllers
{
    [Route("api/services")]
    [ApiController]

    public class ServicesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ServicesController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDataAsync()
        {
            var services = await _context.Services.ToListAsync();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetService([FromRoute] int id)
        {
            var service =  await _context.Services.FindAsync(id);

            if(service == null)
            {
                return BadRequest("Service Invalid");
            }

            return Ok(service);

        }
    }
}
