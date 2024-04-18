using BrochureAPI.Dtos.Service;
using BrochureAPI.Models;

namespace BrochureAPI.Mappers
{
    public static class ServicesMapper
    {
        public static ServicesDto toServicesDto(this Services services)
        {
            return new ServicesDto
            {
                Id = services.Id ,
                Title = services.Title,
                Description = services.Description
            };
        }

        public static Services toServices(this ServicesDto servicesDto)
        {
            return new Services { Title = servicesDto.Title, Description = servicesDto.Description };
        }
    }
}
