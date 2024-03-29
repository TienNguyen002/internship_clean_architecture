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
        /// Getting List Of Request Forms With Pagination
        /// </summary>
        /// <param name="query"> Query By User Input To Get Request Form </param>
        /// <param name="pagingModel"> Model Pagination Filter </param>
        /// <returns> List Of Request Forms Filter By Query With Pagination </returns>
        [HttpGet]
        public async Task<ActionResult<RequestFormDTO>> GetPagedRequestForms([AsParameters] RequestFormQuery query,
            PagingModel model)
        {
            _logger.LogInformation(LogManagements.LogGetRequestFormByQuery);
            var result = await _service.GetPagedRequestFormAsync(query, model);
            _logger.LogInformation(LogManagements.LogReturnRequestFormByQuery);
            return Ok(ApiResponse.Success(result, ResponseManagements.SuccessGetRequestFormByQuery));
        }

        /// <summary>
        /// Create New Request Forms
        /// </summary>
        /// <param name="model"> Model to create </param>
        /// <returns> Create Request Form </returns>
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
    }
}
