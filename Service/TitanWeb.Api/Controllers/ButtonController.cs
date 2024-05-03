using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TitanWeb.Api.Response;
using TitanWeb.Domain.Constants;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ButtonController : ControllerBase
    {
        private readonly IButtonService _service;
        private readonly ILogger<ItemController> _logger;
        public ButtonController(IButtonService service, ILogger<ItemController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Change Button Status
        /// </summary>
        /// <param name="itemSlug"> Slug of Item want to find to change button status </param>
        /// <returns> Change Button Status </returns>
        [HttpPut("changeStatus")]
        public async Task<ActionResult> ChangeButtonStatus(string itemSlug)
        {
            _logger.LogInformation(LogManagements.LogChangeButtonStatus);
            var button = await _service.ChangeButtonStatus(itemSlug);
            if (!button)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest, ResponseManagements.FailToChangeButtonStatus));
            }
            return Ok(ApiResponse.Success(button, ResponseManagements.SuccessChangeButtonStatus));
        }
    }
}
