using BrochureAPI.Dtos.Service;
using BrochureAPI.Helpers;
using BrochureAPI.Models;

namespace BrochureAPI.Interfaces
{
    public interface IServices
    {
        Task<List<Services>> GetAll(QueryObject query);
        Task<Services?> GetService(int id);
        Task<Services?> CreateService(Services service);

        Task<Services> UpdateService(int id , UpdateServiceDto service);

        Task<Services> DeleteService(int id);
    }
}
