using Asp.Versioning;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TitanWeb.Api.Response;
using TitanWeb.Application.DTO.Section;
using TitanWeb.Domain.Constants;
using TitanWeb.Domain.DTO;
using TitanWeb.Domain.DTO.Section;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _service;
        private readonly ILogger<SectionController> _logger;
        private readonly IMapper _mapper;
        public SectionController(ISectionService service, ILogger<SectionController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Sections by Language
        /// </summary>
        /// <param name="localeQuery"> Locale of Section (en, ja) </param>
        /// <returns> List of Sections by Language </returns>
        [HttpGet()]
        public async Task<ActionResult<IList<SectionDTO>>> GetAllSections([FromQuery] LocaleQuery localeQuery)
        {
            _logger.LogInformation(LogManagements.LogGetAllSections);
            var sections = await _service.GetAllSectionAsync(localeQuery);
            _logger.LogInformation(LogManagements.LogReturnSection);
            return Ok(ApiResponse.Success(sections, ResponseManagements.SuccessGetAllSections));
        }

        /// <summary>
        /// Get Section by Id
        /// </summary>
        /// <param name="id"> Id of the Section to get </param>
        /// <returns> Section with the specified Id </returns>
        [HttpGet("byid/{id}")]
        public async Task<ActionResult<SectionDetailDTO>> GetSectionById(int id)
        {
            _logger.LogInformation(LogManagements.LogGetSectionById + id);
            var section = await _service.GetSectionByIdAsync(id);
            if (section == null)
            {
                return Ok(ApiResponse.Success(section, ResponseManagements.NotFoundSectionIdMsg + id));
            }
            _logger.LogInformation(LogManagements.LogReturnSectionById + id);
            return Ok(ApiResponse.Success(section, ResponseManagements.SuccessGetSectionById + id));
        }

        /// <summary>
        /// Get Section By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug of the Section to get </param>
        /// <param name="localeQuery"> Locale of Section (en, ja) </param>
        /// <returns> Section with specified UrlSlug </returns>
        [HttpGet("byslug/{slug}")]
        public async Task<ActionResult<SectionDTO>> GetSectionBySlug(string slug, [FromQuery] LocaleQuery localeQuery)
        {
            _logger.LogInformation(LogManagements.LogGetSectionBySlug + slug);
            var section = await _service.GetSectionBySlugAsync(slug, localeQuery);
            if (section == null)
            {
                return Ok(ApiResponse.Success(section, ResponseManagements.NotFoundSectionSlugMsg + slug));
            }
            _logger.LogInformation(LogManagements.LogReturnSectionBySlug + slug);
            return Ok(ApiResponse.Success(section, ResponseManagements.SuccessGetSectionBySlug + slug));
        }

        /// <summary>
        /// Add/Update Section
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Section/editSection
        ///     {
        ///         "Id"= "216", (Id = 0 to Create, Id != to Update)
        ///         "Name"= "Services"
        ///         "Title"= "WE PROVIDE",
        ///         "UrlSlug"= "services",
        ///         "Description"= "Professional and trusted services with cost-effective and exceptional expertise to deal with any complexities in scalable projects",
        ///         "BackgroundImage"="@myImage.png;type=image/png"
        ///         "Locale"="en" (`en` or `ja`)
        ///     }
        /// </remarks>
        /// <param name="model"> Model to add/update </param>
        /// <returns> Added/Updated Section </returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("editSection")]
        public async Task<ActionResult> EditSection([FromForm] SectionEditModel model)
        {
            _logger.LogInformation(LogManagements.LogEditSection);
            var sectionEdit = await _service.EditSectionAsync(model);
            if (!sectionEdit)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest, ResponseManagements.FailToEditSection));
            }
            var result = _mapper.Map<SectionDTO>(model);
            return Ok(ApiResponse.Success(result, ResponseManagements.SuccessEditSection));
        }

        /// <summary>
        /// Delete Section By Id
        /// </summary>
        /// <param name="id"> Id of "Section" want to delete </param>
        /// <returns> Delete Section By Id </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSection(int id)
        {
            _logger.LogInformation(LogManagements.LogDeleteSection + id);
            var result = await _service.DeleteSectionAsync(id);
            if (!result)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest, ResponseManagements.FailToDeleteSection + id));
            }
            return Ok(ApiResponse.Success(result, ResponseManagements.SuccessDeleteSection + id));
        }
    }
}
