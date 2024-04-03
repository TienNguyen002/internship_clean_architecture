using Microsoft.AspNetCore.Mvc;
using System.Net;
using TitanWeb.Api.Response;
using TitanWeb.Application.DTO.Section;
using TitanWeb.Domain.Constants;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _service; 
        private readonly ILogger<SectionController> _logger;
        public SectionController(ISectionService service, ILogger<SectionController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Get Section By Language
        /// </summary>
        /// <param name="language"> Language want to get Section (en, ja) </param>
        /// <returns> List Of Sections With Language </returns>

        [HttpGet("{language}")]
        public async Task<ActionResult<IList<SectionDTO>>> GetAllSections(string language)
        {
            _logger.LogInformation(LogManagements.LogGetAllSections);
            var sections = await _service.GetAllSectionAsync(language);
            _logger.LogInformation(LogManagements.LogReturnSection);
            return Ok(ApiResponse.Success(sections, ResponseManagements.SuccessGetAllSections));
        }

        /// <summary>
        /// Get Section By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get Section </param>
        /// <returns> Section With UrlSlug want to get </returns>
        [HttpGet("byslug/{slug}")]
        public async Task<ActionResult<SectionDTO>> GetSectionBySlug(string slug)
        {
            _logger.LogInformation(LogManagements.LogGetSectionBySlug + slug);
            var section = await _service.GetSectionBySlugAsync(slug);
            if(section == null)
            {
                return Ok(ApiResponse.Success(HttpStatusCode.OK, ResponseManagements.NotFoundSectionSlugMsg + slug));
            }
            _logger.LogInformation(LogManagements.LogReturnSectionBySlug + slug);
            return Ok(ApiResponse.Success(section, ResponseManagements.SuccessGetSectionBySlug + slug));
        }
    }
}
