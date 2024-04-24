using BrochureAPI.Dtos.Service;
using BrochureAPI.Helpers;
using BrochureAPI.Models;

namespace BrochureAPI.Interfaces
{
    public interface IServices
    {
        Task<List<BrochureAPI.Models.Services>> GetAll(QueryObject query);
        Task<BrochureAPI.Models.Services?> GetService(int id);
        Task<BrochureAPI.Models.Services?> CreateService(BrochureAPI.Models.Services service);

        Task<BrochureAPI.Models.Services> UpdateService(int id , UpdateServiceDto service);

        Task<BrochureAPI.Models.Services> DeleteService(int id);
    }
}
