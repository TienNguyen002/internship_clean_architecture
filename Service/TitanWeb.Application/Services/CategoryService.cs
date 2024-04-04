using MapsterMapper;
using TitanWeb.Domain.DTO.Category;
using TitanWeb.Domain.Interfaces.Repositories;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get Category by UrlSlug With Language
        /// </summary>
        /// <param name="slug"> UrlSlug of Category want to get </param>
        /// <param name="language"> Language of Category want to get (like: en, ja) </param>
        /// <returns> Category Has Slug want to get with language, Map Data to CategoryDTO </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<CategoryDTO> GetCategoryBySlugWithLanguageAsync(string slug, string language)
        {
            var category = await _repository.GetCategoryBySlugAsync(slug, language);
            return _mapper.Map<CategoryDTO>(category);
        }
    }
}
