using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TitanWeb.Api.Response;
using TitanWeb.Domain.Constants;
using TitanWeb.Domain.DTO.Image;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        /// Get All Image
        /// </summary>
        /// <returns> Response List Of Image </returns>
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
        /// <param name="id"> Id of Image Want To Get </param>
        /// <returns> Response Image By Id want to get </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageDTO>> GetImageById(int id)
        {
            _logger.LogInformation(LogManagements.LogGetImageById + id);
            var image = await _imageService.GetImageByIdAsync(id);
            if(image == null)
            {
                return Ok(ApiResponse.Success(HttpStatusCode.OK, ResponseManagements.NotFoundImageIdMsg + id));
            }
            _logger.LogInformation(LogManagements.LogReturnImageById + id);
            return Ok(ApiResponse.Success(image, ResponseManagements.SuccessGetImageById + id));
        }

        /// <summary>
        /// Add New Image
        /// </summary>
        /// <param name="model"> Model Of Image To Add </param>
        /// <returns> Added Image </returns>
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
        /// Delete Image By Id
        /// </summary>
        /// <param name="id"> Id of Image Want To Delete </param>
        /// <returns> Deleted Image </returns>
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
        /// Get All Logo Image
        /// </summary>
        /// <returns> A List Of Logos </returns>
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
