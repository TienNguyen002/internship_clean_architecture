using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TitanWeb.Api.Response;
using TitanWeb.Domain.Constants;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubItemController : ControllerBase
    {
        private readonly ISubItemService _service;
        private readonly ILogger<SubItemController> _logger;
        private readonly IMapper _mapper;
        public SubItemController(ISubItemService service, ILogger<SubItemController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Delete Sub-Item By Id
        /// </summary>
        /// <param name="id"> Id Of Sub-Item want to delete </param>
        /// <returns> Delete Sub-Item By Id </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubItem(int id)
        {
            _logger.LogInformation(LogManagements.LogDeleteSubItem + id);
            var result = await _service.DeleteSubItemAsync(id);
            if (!result)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest, ResponseManagements.FailToDeleteSubItem + id));
            }
            return Ok(ApiResponse.Success(result, ResponseManagements.SuccessDeleteSubItem + id)); ;
        }
    }
}
