using MapsterMapper;
using TitanWeb.Domain.DTO;
using TitanWeb.Domain.DTO.Category;
using TitanWeb.Domain.Interfaces.Repositories;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMapperService _mapperService;
        public CategoryService(ICategoryRepository repository, IMapper mapper, IMapperService mapperService)
        {
            _repository = repository;
            _mapper = mapper;
            _mapperService = mapperService;
        }

        /// <summary>
        /// Get Category by UrlSlug
        /// </summary>
        /// <param name="slug"> UrlSlug of Category want to get </param>
        /// <param name="localeQuery"> Locale of Category (en, ja) </param>
        /// <returns> Category Has Slug want to get with language, Map Data to CategoryDTO </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<CategoryDTO> GetCategoryBySlugAsync(string slug, LocaleQuery localeQuery)
        {
            var category = await _repository.GetCategoryBySlugAsync(slug);
            var categoryDTO = _mapper.Map<CategoryDTO>(category);
            categoryDTO.Items = await _mapperService.MapItemsAsync(category.Items, localeQuery);
            return categoryDTO;
        }
    }
}
