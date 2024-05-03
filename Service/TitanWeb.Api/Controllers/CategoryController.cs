using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TitanWeb.Api.Response;
using TitanWeb.Domain.Constants;
using TitanWeb.Domain.DTO;
using TitanWeb.Domain.DTO.Category;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
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
        /// Get a Category by UrlSlug and language
        /// </summary>
        /// <param name="slug"> UrlSlug of the Category to retrieve </param>
        /// <param name="localeQuery"> Locale of Category (en, ja) </param>
        /// <returns>Custom response containing the Category with the specified slug and language and other infos. </returns>
        [HttpGet("{slug}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryBySlug(string slug, [FromQuery] LocaleQuery localeQuery)
        {
            _logger.LogInformation(LogManagements.LogGetCategoryBySlug + slug);
            var category = await _service.GetCategoryBySlugAsync(slug, localeQuery);
            if (category == null)
            {
                return Ok(ApiResponse.Success(category, ResponseManagements.NotFoundCategoryBySlugMsg + slug));
            }
            _logger.LogInformation(LogManagements.LogReturnCategoryBySlug + slug);
            return Ok(ApiResponse.Success(category, ResponseManagements.SuccessGetCategoryBySlug + slug));
        }
    }
}
