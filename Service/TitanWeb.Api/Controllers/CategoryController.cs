using Microsoft.AspNetCore.Mvc;
using TitanWeb.Api.Response;
using TitanWeb.Domain.Constants;
using TitanWeb.Domain.DTO.Category;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(ICategoryService service, ILogger<CategoryController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Get Category by UrlSlug
        /// </summary>
        /// <param name="slug"> UrlSlug of Category want to get </param>
        /// <param name="language"> Language of Category want to get (like: en, ja) </param>
        /// <returns> Response Category Has Slug want to get with language </returns>
        [HttpGet("{slug}/{language}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryBySlug(string slug, string language)
        {
            _logger.LogInformation(LogManagements.LogGetCategoryBySlug + slug);
            var category = await _service.GetCategoryBySlugAsync(slug, language);
            _logger.LogInformation(LogManagements.LogReturnCategoryBySlug + slug);
            return Ok(ApiResponse.Success(category, ResponseManagements.SuccessGetCategoryBySlug + slug));
        }
    }
}
