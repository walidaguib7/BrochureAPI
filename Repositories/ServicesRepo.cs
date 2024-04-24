using BrochureAPI.Data;
using BrochureAPI.Dtos.Service;
using BrochureAPI.Helpers;
using BrochureAPI.Interfaces;
using BrochureAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BrochureAPI.Repositories
{
    public class ServicesRepo : IServices
    {
        private readonly ApplicationDBContext dBContext;
        public ServicesRepo(ApplicationDBContext context)
        {
            dBContext = context;
        }
        public async Task<BrochureAPI.Models.Services?> CreateService(BrochureAPI.Models.Services service)
        {
            await dBContext.Services.AddAsync(service);
            await dBContext.SaveChangesAsync();
            return service;
        }

        public async Task<BrochureAPI.Models.Services?> DeleteService(int id)
        {
            var service = await dBContext.Services.FindAsync(id);
            if(service == null) {
                return null;
            }

            dBContext.Services.Remove(service);
            await dBContext.SaveChangesAsync();
            return service;
        }

        public async Task<List<BrochureAPI.Models.Services>> GetAll(QueryObject query)
        {
            var services = dBContext.Services.AsQueryable();

            if (!string.IsNullOrEmpty(query.Title))
            {
                services = services.Where(s => s.Title.Contains(query.Title));
            }

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                if (query.SortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    services = query.IsDescending ? services.OrderByDescending(s => s.Title) : services.OrderBy(s => s.Title);
                }
            }
            var skipNumber = (query.PageNumber - 1) * query.Limit;

            return await services.Skip(skipNumber).Take(query.Limit).ToListAsync();

        }

        public async Task<BrochureAPI.Models.Services?> GetService(int id)
        {
            return await dBContext.Services.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<BrochureAPI.Models.Services> UpdateService(int id, UpdateServiceDto serviceDto)
        {
            var service = await dBContext.Services.FirstOrDefaultAsync(s => s.Id == id);
            if(service == null)
            {
                return null;
            }

            service.Title = serviceDto.Title;
            service.Description = serviceDto.Description;
            await dBContext.SaveChangesAsync();
            return service;
        }
    }
}
