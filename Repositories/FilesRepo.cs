using BrochureAPI.Interfaces;
using BrochureAPI.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;
using BrochureAPI.Data;

namespace BrochureAPI.Repositories
{
    public class FilesRepo : IFiles
    {
        private readonly ApplicationDBContext _context;
        public FilesRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<FilesModel> UploadFile(FilesModel file)
        {
            await _context.Files.AddAsync(file);
            await _context.SaveChangesAsync();
            return file;
        }
    }
}
