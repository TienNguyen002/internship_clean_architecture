﻿using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TitanWeb.Api.Response;
using TitanWeb.Domain.Constants;
using TitanWeb.Domain.DTO;
using TitanWeb.Domain.DTO.Items;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Api.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _service;
        private readonly ILogger<ItemController> _logger;
        private readonly IMapper _mapper;
        public ItemController(IItemService service, ILogger<ItemController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Getting List Of Item With Pagination
        /// </summary>
        /// <param name="query"> Query By User Input To Get Item </param>
        /// <param name="pagingModel"> Model Pagination Filter </param>
        /// <returns> List Of Item Filter By Query With Pagination </returns>
        [HttpGet("paged")]
        public async Task<ActionResult<ItemDTO>> GetPagedItem([AsParameters] ItemQuery query,
            PagingModel model)
        {
            _logger.LogInformation(LogManagements.ValidateInput);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _logger.LogInformation(LogManagements.LogGetItemByQuery);
            var result = await _service.GetPagedItemAsync(query, model);
            _logger.LogInformation(LogManagements.LogReturnItemByQuery);
            return Ok(ApiResponse.Success(result, ResponseManagements.SuccessGetItemByQuery));
        }

        /// <summary>
        /// Get Item By Id
        /// </summary>
        /// <param name="id"> Id Of Item want to get </param>
        /// <returns> Get Item By Id </returns>
        [HttpGet("byid/{id}")]
        public async Task<ActionResult<ItemDTO>> GetItemById(int id)
        {
            _logger.LogInformation(LogManagements.LogGetItemById + id);
            var item = await _service.GetItemByIdAsync(id);
            if(item == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound, ResponseManagements.NotFoundItemIdMsg + id));
            }
            _logger.LogInformation(LogManagements.LogReturnItemById + id);
            return Ok(ApiResponse.Success(item, ResponseManagements.SuccessGetItemById + id));
        }

        /// <summary>
        /// Get Item By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get Item </param>
        /// <returns> Item With UrlSlug want to get </returns>
        [HttpGet("byslug/{slug}")]
        public async Task<ActionResult<ItemDTO>> GetItemBySlug(string slug)
        {
            _logger.LogInformation(LogManagements.LogGetItemBySlug + slug);
            var item = await _service.GetItemBySlugAsync(slug);
            if(item == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound, ResponseManagements.NotFoundItemSlugMsg + slug));
            }
            _logger.LogInformation(LogManagements.LogReturnItemBySlug + slug);
            return Ok(ApiResponse.Success(item, ResponseManagements.SuccessGetItemBySlug + slug));
        }

        /// <summary>
        /// Get Item By Category Slug
        /// </summary>
        /// <param name="categorySlug"> Slug of Category want to get Items </param>
        /// <param name="language"> Language of category want to get (en, ja) </param>
        /// <returns> A List Of Item By Category Slug filter language </returns>
        [HttpGet("{categorySlug}/{language}")]
        public async Task<ActionResult<ItemDTO>> GetItemByCategorySlug(string categorySlug, string language)
        {
            _logger.LogInformation(LogManagements.LogGetItemByCategorySlug + categorySlug);
            var item = await _service.GetItemsByCategorySlugAsync(categorySlug, language);
            if (item == null)
            {
                return NotFound(ApiResponse.Fail(HttpStatusCode.NotFound, ResponseManagements.NotFoundItemCategorySlugMsg + categorySlug));
            }
            _logger.LogInformation(LogManagements.LogReturnItemByCategorySlug + categorySlug);
            return Ok(ApiResponse.Success(item, ResponseManagements.SuccessGetItemByCategorySlug + categorySlug));
        }

        /// <summary>
        /// Add/Update News
        /// </summary>
        /// <param name="model"> Model to add/update </param>
        /// <returns> Added/Updated News </returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("createNews")]
        public async Task<ActionResult> EditNews([FromForm] NewsEditModel model)
        {
            _logger.LogInformation(LogManagements.ValidateInput);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _logger.LogInformation(LogManagements.LogEditNews);
            var newsCreate = await _service.EditNewsAsync(model);
            if (!newsCreate)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest, ResponseManagements.FailToEditNews));
            }
            var result = _mapper.Map<ItemDTO>(model);
            return Ok(ApiResponse.Success(result, ResponseManagements.SuccessEditNews));
        }

        /// <summary>
        /// Get Item By Id
        /// </summary>
        /// <param name="id"> Id Of Item want to get </param>
        /// <returns> Get Item By Id </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            _logger.LogInformation(LogManagements.LogDeleteItem + id);
            var result = await _service.DeleteNewsAsync(id);
            if (!result)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest, ResponseManagements.FailToDeleteItem + id));
            }
            return Ok(ApiResponse.Success(result, ResponseManagements.SuccessDeleteItem + id));;
        }

        /// <summary>
        /// Change Image For Item
        /// </summary>
        /// <param name="imageId"> Id Of Image want to change for Item </param>
        /// <returns> Image Item Changed </returns>
        [HttpPut("changeLogo/{imageId}")]
        public async Task<ActionResult> ChangeLogo(int imageId)
        {
            _logger.LogInformation(LogManagements.LogChangeLogo);
            var newItem = await _service.ChangeLogoImage(imageId);
            if (!newItem)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest, ResponseManagements.FailToChangeLogo));
            }
            var result = _mapper.Map<ItemDTO>(newItem);
            return Ok(ApiResponse.Success(newItem, ResponseManagements.SuccessChangeLogo));
        }
    }
}
