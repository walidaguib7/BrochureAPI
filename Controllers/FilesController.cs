using BrochureAPI.Interfaces;
using BrochureAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrochureAPI.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFiles _repo;
        public FilesController(IFiles repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFiles(IFormFile file)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var Image = await _repo.UploadImage(file);


            var files = await _repo.UploadFile(new Models.FilesModel { Image = Image });
            if(files == null)
            {
                return NotFound();
            }

            return Ok(files);
        }
        
    }
}
