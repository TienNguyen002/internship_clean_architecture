using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TitanWeb.Api.Response;
using TitanWeb.Application.DTO.Section;
using TitanWeb.Domain.Constants;
using TitanWeb.Domain.DTO.Section;
using TitanWeb.Domain.Entities;
using TitanWeb.Domain.Interfaces.Services;
using TitanWeb.Infrastructure.Contexts;

namespace TitanWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _service;
        private readonly ILogger<SectionController> _logger;
        private readonly IMapper _mapper;
        private readonly TitanWebContext _context;
        public SectionController(ISectionService service, ILogger<SectionController> logger, IMapper mapper, TitanWebContext context)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
            _context = context;
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
            if (section == null)
            {
                return Ok(ApiResponse.Success(HttpStatusCode.OK, ResponseManagements.NotFoundSectionSlugMsg + slug));
            }
            _logger.LogInformation(LogManagements.LogReturnSectionBySlug + slug);
            return Ok(ApiResponse.Success(section, ResponseManagements.SuccessGetSectionBySlug + slug));
        }

        /// <summary>
        /// Add/Update Section
        /// </summary>
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
        /// Get Section By Id
        /// </summary>
        /// <param name="id"> Id Of Section want to get </param>
        /// <returns> Get Section By Id </returns>
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

        /// <summary>
        /// Move Section
        /// </summary>
        /// <param name="sourceSection">Section want to move</param>
        /// <param name="destinationSection">Place Section want to move to</param>
        /// <returns> Section moved </returns>
        [HttpPut("moveSection/{sourceSection}to{destinationSection}")]
        public async Task<ActionResult> MoveSection(string sourceSection, string destinationSection)
        {
            _logger.LogInformation(LogManagements.LogMoveSection, sourceSection, destinationSection);
            var result = await _service.MoveSection(sourceSection, destinationSection);
            if (!result)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest, ResponseManagements.FailToMoveSection, sourceSection, destinationSection));
            }
            return Ok(ApiResponse.SuccessMsg(result, HttpStatusCode.OK, ResponseManagements.SuccessMoveSection, sourceSection, destinationSection));
        }
    }
}
