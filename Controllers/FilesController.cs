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
        public async Task<IActionResult> UploadFiles(IFormFile BImage , IFormFile SImage)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var BigImage = await _repo.UploadImage(BImage, false);
            var SmallImage = await _repo.UploadImage(SImage, true);

            var files = await _repo.UploadFile(new Models.FilesModel { Content_Image = BigImage, Description_Image = SmallImage });
            if(files == null)
            {
                return NotFound();
            }

            return Ok(files);
        }
        
    }
}
