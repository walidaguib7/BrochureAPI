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
        [Route("{id:int}")]
        public async Task<IActionResult> UploadFile([FromRoute] int id ,  IFormFile file)
        {
            if (file.Length == 0 || file == null)
            {
                throw new Exception("file Not Found!");
            }
            if (file.Length > 1048576) // 1 MB limit
            {
                throw new Exception("The maximum file size must be 1mb!");
            }
            var AllowedExtensions = new List<string> { ".jpg", ".jpeg", ".png" };
            var extension = Path.GetExtension(file.FileName).ToLower();
            if (!AllowedExtensions.Contains(extension))
            {
                throw new Exception("Invalid file format. Only JPG, JPEG, and PNG files are allowed.");
            }
            string fileName = Path.GetFileName(file.FileName);
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
            string filePath = Path.Combine(@"D:\AW7\BrochureAPI\Uploads\Blog", uniqueFileName);

            try
            {
                await using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var files = await _repo.UploadFile(new Models.FilesModel{ FilePath = filePath, BlogId = id });

            return Ok(files);
        }
    }
}
