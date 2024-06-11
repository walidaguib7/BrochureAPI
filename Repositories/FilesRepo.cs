using BrochureAPI.Interfaces;
using BrochureAPI.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;
using BrochureAPI.Data;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace BrochureAPI.Repositories
{
    public class FilesRepo : IFiles
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment environment;
        public FilesRepo(ApplicationDBContext context , IWebHostEnvironment environment)
        {
            _context = context;
            this.environment = environment;
        }

        public async Task<FilesModel> UploadFile(FilesModel file)
        {
            await _context.Files.AddAsync(file);
            await _context.SaveChangesAsync();
            return file;
        }

        public async Task<string> UploadImage(IFormFile file)
        {
            if (file.Length == 0 || file == null)
            {
                throw new Exception("file Not Found!");
            }
            var AllowedExtensions = new List<string> { ".jpg", ".jpeg", ".png" };
            var extension = Path.GetExtension(file.FileName).ToLower();
            if (!AllowedExtensions.Contains(extension))
            {
                throw new Exception("Invalid file format. Only JPG, JPEG, and PNG files are allowed.");
            }
            string fileName = Path.GetFileName(file.FileName);
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
            string filePath = Path.Combine("Images",uniqueFileName);

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

            return uniqueFileName;

        }
    }
}
