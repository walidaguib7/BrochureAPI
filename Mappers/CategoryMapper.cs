using BrochureAPI.Dtos.Category;
using BrochureAPI.Models;

namespace BrochureAPI.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto { Id = category.Id, Title = category.Title, Description = category.Description };
        }

        public static Category ToCategory(this CreateCategoryDto categoryDto)
        {
            return new Category { Title = categoryDto.Title, Description = categoryDto.Description };
        }
    }
}
