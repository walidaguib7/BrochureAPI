using BrochureAPI.Models;

namespace BrochureAPI.Interfaces
{
    public interface IFiles
    {
        Task<FilesModel> UploadFile(FilesModel file);

        Task<string> UploadImage(IFormFile file , bool IsSmall);

        
    }
}
