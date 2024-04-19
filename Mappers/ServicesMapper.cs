using BrochureAPI.Dtos.Service;
using BrochureAPI.Models;

namespace BrochureAPI.Mappers
{
    public static class ServicesMapper
    {
        // we convert service model to dto to read it without id or in a certain way the user want to see
        public static ServicesDto ToServicesDto(this Services services)
        {
            return new ServicesDto
            {
                Id = services.Id,
                Title = services.Title,
                Description = services.Description
            };
        }

        // return create Service dto to a model to insert it into db
        public static Services ToServices(this CreateServiceDto servicesDto)
        {
            return new Services { Title = servicesDto.Title, Description = servicesDto.Description };
        }
    }
}
