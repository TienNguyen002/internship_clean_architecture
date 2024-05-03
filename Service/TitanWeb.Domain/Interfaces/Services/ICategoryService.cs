using TitanWeb.Domain.DTO;
using TitanWeb.Domain.DTO.Category;

namespace TitanWeb.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<CategoryDTO> GetCategoryBySlugAsync(string slug, LocaleQuery query);
    }
}
