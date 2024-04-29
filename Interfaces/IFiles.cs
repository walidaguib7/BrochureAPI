using BrochureAPI.Models;

namespace BrochureAPI.Interfaces
{
    public interface IFiles
    {
        Task<FilesModel> UploadFile(FilesModel file);
    }
}
