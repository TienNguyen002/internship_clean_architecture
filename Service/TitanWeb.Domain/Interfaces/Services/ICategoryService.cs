using TitanWeb.Domain.DTO.Category;

namespace TitanWeb.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<CategoryDTO> GetCategoryBySlugWithLanguageAsync(string slug, string language);
    }
}
