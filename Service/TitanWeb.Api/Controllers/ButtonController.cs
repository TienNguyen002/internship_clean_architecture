using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TitanWeb.Api.Response;
using TitanWeb.Domain.Constants;
using TitanWeb.Domain.DTO.Items;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        /// <param name="slug"> Slug of button want to change status </param>
        /// <returns> Change Button Statusd </returns>
        [HttpPut("changeStatus")]
        public async Task<ActionResult> ChangeButtonStatus(string slug)
        {
            _logger.LogInformation(LogManagements.LogChangeButtonStatus);
            var button = await _service.ChangeButtonStatus(slug);
            if (!button)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest, ResponseManagements.FailToChangeButtonStatus));
            }
            return Ok(ApiResponse.Success(button, ResponseManagements.SuccessChangeButtonStatus));
        }
    }
}
