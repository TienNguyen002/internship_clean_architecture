using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TitanWeb.Api.Response;
using TitanWeb.Domain.Constants;
using TitanWeb.Domain.DTO;
using TitanWeb.Domain.DTO.RequestForm;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RequestFormController : ControllerBase
    {
        private readonly IRequestFormService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<RequestFormController> _logger;
        public RequestFormController(IRequestFormService service, IMapper mapper, ILogger<RequestFormController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get all "Request for Info" Form Responses
        /// </summary>
        /// <param name="query"> Query to filter the Form Reponses</param>
        /// <param name="pagingModel"> Pagination Model </param>
        /// <returns> Paged list of "Request for Info" Form Response filtered by Query </returns>
        [HttpGet]
        public async Task<ActionResult<RequestFormDTO>> GetPagedRequestForms([FromQuery] RequestFormQuery query,
            [FromQuery] PagingModel model)
        {
            _logger.LogInformation(LogManagements.LogGetRequestFormByQuery);
            var result = await _service.GetPagedRequestFormAsync(query, model);
            _logger.LogInformation(LogManagements.LogReturnRequestFormByQuery);
            return Ok(ApiResponse.Success(result, ResponseManagements.SuccessGetRequestFormByQuery));
        }

        /// <summary>
        /// Post a new "Request for Info"
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/RequestForm
        ///     {
        ///         "Name"= "John Smith",
        ///         "Email"= "johnsmith@gmail.com",
        ///         "Phone"= "0123467891",
        ///         "Subject"= "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
        ///         "Message"= "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
        ///     }
        /// </remarks>
        /// <param name="model"> Model to create new "Request for Info"</param>
        /// <returns> Result of the operation (True/False) </returns>
        [HttpPost]
        public async Task<ActionResult> CreateRequestForm([FromForm] RequestFormEditModel model)
        {
            _logger.LogInformation(LogManagements.ValidateInput);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _logger.LogInformation(LogManagements.LogCreateRequestForm);
            var requestFormCreate = await _service.CreateRequestFormAsync(model);
            if (!requestFormCreate)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest, ResponseManagements.FailToCreateImage));
            }
            var result = _mapper.Map<RequestFormDTO>(model);
            return Ok(ApiResponse.Success(result, ResponseManagements.SuccessCreateRequestForm));
        }

        /// <summary>
        /// Delete "Request for Information" by Id
        /// </summary>
        /// <param name="id"> Id of the "Request for Info" to delete </param>
        /// <returns> Result of the operation (True/False) </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRequestForm(int id)
        {
            _logger.LogInformation(LogManagements.LogDeleteRequestForm + id);
            var result = await _service.DeleteRequestFormAsync(id);
            if (!result)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest, ResponseManagements.FailToDeleteRequestForm + id));
            }
            return Ok(ApiResponse.Success(result, ResponseManagements.SuccessDeleteRequestForm + id)); ;
        }
    }
}
