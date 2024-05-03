using Asp.Versioning;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TitanWeb.Api.Response;
using TitanWeb.Domain.Constants;
using TitanWeb.Domain.DTO.Image;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;
        private readonly ILogger<ImageController> _logger;
        public ImageController(IImageService imageService, IMapper mapper, ILogger<ImageController> logger)
        {
            _imageService = imageService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get all Images
        /// </summary>
        /// <returns> A list of all Images </returns>
        [HttpGet("getAll")]
        public async Task<ActionResult<IList<ImageDTO>>> GetAllImages()
        {
            _logger.LogInformation(LogManagements.LogGetAllImages);
            var images = await _imageService.GetAllImagesAsync();
            _logger.LogInformation(LogManagements.LogReturnImage);
            return Ok(ApiResponse.Success(images, ResponseManagements.SuccessGetAllImages));
        }

        /// <summary>
        /// Get Image By Id
        /// </summary>
        /// <param name="id"> Id of the Image to get </param>
        /// <returns> The Image to get </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageDTO>> GetImageById(int id)
        {
            _logger.LogInformation(LogManagements.LogGetImageById + id);
            var image = await _imageService.GetImageByIdAsync(id);
            if (image == null)
            {
                return Ok(ApiResponse.Success(image, ResponseManagements.NotFoundImageIdMsg + id));
            }
            _logger.LogInformation(LogManagements.LogReturnImageById + id);
            return Ok(ApiResponse.Success(image, ResponseManagements.SuccessGetImageById + id));
        }

        /// <summary>
        /// Creates a new Image
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Image
        ///     {
        ///         "ImageFile"="@myImage.png;type=image/png",
        ///         "Hyperlink"= "https://example.com",
        ///         "IsLogo"="false"
        ///     }
        /// </remarks>
        /// <param name="model"> Model of the Image to add </param>
        /// <returns> The added Image </returns>
        [HttpPost]
        public async Task<ActionResult> AddImage([FromForm] ImageEditModel model)
        {
            _logger.LogInformation(LogManagements.ValidateInput);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _logger.LogInformation(LogManagements.LogCreateImage);
            var imageCreate = await _imageService.AddImageAsync(model);
            if (!imageCreate)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest, ResponseManagements.FailToCreateImage));
            }
            var result = _mapper.Map<ImageDTO>(model);
            return Ok(ApiResponse.Success(result, ResponseManagements.SuccessCreateImage));
        }

        /// <summary>
        /// Delete Image by Id
        /// </summary>
        /// <param name="id"> Id of the Image To Delete </param>
        /// <returns> Result of the Delete operation (True/False) </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteImageById(int id)
        {
            _logger.LogInformation(LogManagements.LogDeleteImage + id);
            var result = await _imageService.DeleteImageAsync(id);
            if (!result)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest, ResponseManagements.FailToDeleteImage + id));
            }
            return Ok(ApiResponse.Success(result, ResponseManagements.SuccessDeleteImage + id));
        }

        /// <summary>
        /// Get all Logos
        /// </summary>
        /// <returns> A List of Logos </returns>
        [HttpGet("getLogos")]
        public async Task<ActionResult<IList<ImageDTO>>> GetAllLogos()
        {
            _logger.LogInformation(LogManagements.LogGetAllLogoImages);
            var logos = await _imageService.GetAllLogos();
            _logger.LogInformation(LogManagements.LogReturnLogoImage);
            return Ok(ApiResponse.Success(logos, ResponseManagements.SuccessGetAllLogoImages));
        }
    }
}
