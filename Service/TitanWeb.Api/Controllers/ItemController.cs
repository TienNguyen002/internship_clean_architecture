using Asp.Versioning;
using MapsterMapper;
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
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
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
        /// Get Items by query with Pagination
        /// </summary>
        /// <param name="query"> Query used to filter the items(section slug) </param>
        /// <param name="localeQuery"> Locale of Item (en, ja) </param>
        /// <param name="model"> Pagination Model </param>
        /// <returns> A paged list of Items filtered by Query </returns>
        [HttpGet("paged")]
        public async Task<ActionResult<ItemDTO>> GetPagedItem([FromQuery] ItemQuery query, [FromQuery] LocaleQuery localeQuery,
             [FromQuery] PagingModel model)
        {
            _logger.LogInformation(LogManagements.ValidateInput);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _logger.LogInformation(LogManagements.LogGetItemByQuery);
            var result = await _service.GetPagedItemAsync(query, localeQuery, model);
            _logger.LogInformation(LogManagements.LogReturnItemByQuery);
            return Ok(ApiResponse.Success(result, ResponseManagements.SuccessGetItemByQuery));
        }

        /// <summary>
        /// Get Item by Id
        /// </summary>
        /// <param name="id"> Id of the Item to get </param>
        /// <returns> Item with the specified Id </returns>
        [HttpGet("byid/{id}")]
        public async Task<ActionResult<ItemDTO>> GetItemById(int id)
        {
            _logger.LogInformation(LogManagements.LogGetItemById + id);
            var item = await _service.GetItemByIdAsync(id);
            if (item == null)
            {
                return Ok(ApiResponse.Success(item, ResponseManagements.NotFoundItemIdMsg + id));
            }
            _logger.LogInformation(LogManagements.LogReturnItemById + id);
            return Ok(ApiResponse.Success(item, ResponseManagements.SuccessGetItemById + id));
        }

        /// <summary>
        /// Get Item by Item Slug
        /// </summary>
        /// <param name="slug"> UrlSlug of the Item to get </param>
        /// <param name="localeQuery"> Locale of Item (en, ja) </param>
        /// <returns> Item with the specified UrlSlug </returns>
        [HttpGet("byslug")]
        public async Task<ActionResult<ItemDTO>> GetItemBySlug(string slug, [FromQuery] LocaleQuery localeQuery)
        {
            _logger.LogInformation(LogManagements.LogGetItemBySlug + slug);
            var item = await _service.GetItemBySlugAsync(slug, localeQuery);
            if (item == null)
            {
                return Ok(ApiResponse.Success(item, ResponseManagements.NotFoundItemSlugMsg + slug));
            }
            _logger.LogInformation(LogManagements.LogReturnItemBySlug + slug);
            return Ok(ApiResponse.Success(item, ResponseManagements.SuccessGetItemBySlug + slug));
        }

        /// <summary>
        /// Get all Items By Category Slug
        /// </summary>
        /// <param name="categorySlug"> UrlSlug of the Category </param>
        /// <param name="localeQuery"> Locale of Item (en, ja) </param>
        /// <returns> A List Of Items that belongs to the specified Category </returns>
        [HttpGet("byCategory")]
        public async Task<ActionResult<ItemDTO>> GetItemByCategorySlug(string categorySlug, [FromQuery] LocaleQuery localeQuery)
        {
            _logger.LogInformation(LogManagements.LogGetItemByCategorySlug + categorySlug);
            var item = await _service.GetItemsByCategorySlugAsync(categorySlug, localeQuery);
            if (item == null)
            {
                return Ok(ApiResponse.Success(item, ResponseManagements.NotFoundItemCategorySlugMsg + categorySlug));
            }
            _logger.LogInformation(LogManagements.LogReturnItemByCategorySlug + categorySlug);
            return Ok(ApiResponse.Success(item, ResponseManagements.SuccessGetItemByCategorySlug + categorySlug));
        }

        /// <summary>
        /// Get all Items By Section Slug, excluding one Item
        /// </summary>
        /// <param name="sectionSlug"> UrlSlug of Section </param>
        /// <param name="urlSlug"> UrlSlug of the Item to exclude </param>
        /// <returns> A List Of Items by Section Slug, excluding the Item with the UrlSlug</returns>
        [HttpGet("all/{sectionSlug}/{urlSlug}")]
        public async Task<ActionResult<ItemDTO>> GetItemBySectionSlug(string sectionSlug, string urlSlug)
        {
            _logger.LogInformation(LogManagements.LogGetItemBySectionSlug + sectionSlug);
            var item = await _service.GetAllItemsBySectionSlugAsync(sectionSlug, urlSlug);
            if (item == null)
            {
                return Ok(ApiResponse.Success(item, ResponseManagements.NotFoundItemSectionSlugMsg + sectionSlug));
            }
            _logger.LogInformation(LogManagements.LogReturnItemBySectionSlug + sectionSlug);
            return Ok(ApiResponse.Success(item, ResponseManagements.SuccessGetItemBySectionSlug + sectionSlug));
        }

        /// <summary>
        /// Add/Update News
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Item/editNews
        ///     {
        ///         "Id"= "126", (Id = 0 to Create, Id != to Update)
        ///         "Title"= "Titan Tet Celebration 2025",
        ///         "JapaneseTitle"= "Titan Tet Celebration 2025",
        ///         "ShortDescription"= "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
        ///         "JapaneseShortDescription"= "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
        ///         "Description"= "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
        ///         "JapaneseDescription"= "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
        ///         "ImageFile"="@myImage.png;type=image/png"
        ///     }
        /// </remarks>
        /// <param name="model"> Model to add/update News </param>
        /// <returns> The added/updated News </returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("editNews")]
        public async Task<ActionResult> EditNews([FromForm] NewsEditModel model)
        {
            _logger.LogInformation(LogManagements.LogEditNews);
            var newsEdit = await _service.EditNewsAsync(model);
            if (!newsEdit)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest, ResponseManagements.FailToEditNews));
            }
            var result = _mapper.Map<ItemDTO>(model);
            return Ok(ApiResponse.Success(result, ResponseManagements.SuccessEditNews));
        }

        /// <summary>
        /// Add/Update Blog
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Item/editBlogs
        ///     {
        ///         "Id"= "216", (Id = 0 to Create, Id != to Update)
        ///         "Title"= "Titan Tet Celebration 2025",
        ///         "JapaneseTitle"= "Titan Tet Celebration 2025",
        ///         "SubTitle (Author)"= "Admin",
        ///         "ShortDescription"= "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
        ///         "JapaneseShortDescription"= "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
        ///         "Description"= "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
        ///         "Japanese"= "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
        ///         "ImageFile"="@myImage.png;type=image/png"
        ///     }
        /// </remarks>
        /// <param name="model"> Model to add/update Blog </param>
        /// <returns> The Added/Updated Blog </returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("editBlog")]
        public async Task<ActionResult> EditBlog([FromForm] BlogEditModel model)
        {
            _logger.LogInformation(LogManagements.LogEditBlog);
            var blogEdit = await _service.EditBlogsAsync(model);
            if (!blogEdit)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest, ResponseManagements.FailToEditBlog));
            }
            var result = _mapper.Map<ItemDTO>(model);
            return Ok(ApiResponse.Success(result, ResponseManagements.SuccessEditBlog));
        }

        /// <summary>
        /// Delete Item By Id
        /// </summary>
        /// <param name="id"> Id of the Item to delete </param>
        /// <returns> Result of the Delete operation (True/False) </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            _logger.LogInformation(LogManagements.LogDeleteItem + id);
            var result = await _service.DeleteNewsAsync(id);
            if (!result)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest, ResponseManagements.FailToDeleteItem + id));
            }
            return Ok(ApiResponse.Success(result, ResponseManagements.SuccessDeleteItem + id)); ;
        }

        /// <summary>
        /// Change the Logo of an Item
        /// </summary>
        /// <param name="imageId"> Id of the new Logo to replace the old Logo </param>
        /// <returns> Result of the Update operation (True/False)  </returns>
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

        /// <summary>
        /// Add/Update Banner
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Item/editBanner
        ///     {
        ///         "Id"= "12", (Id = 0 to Create, Id !=0 to Update)
        ///         "BoldTitle" = "INSPIRE"
        ///         "JapaneseBoldTitle" = "INSPIRE"
        ///         "Title"= "YOUR WORK",
        ///         "JapaneseTitle"= "YOUR WORK",
        ///         "Description"= "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
        ///         "JapaneseDescription"= "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
        ///         "BackgroundImage"="@myImage.png;type=image/png"
        ///     }
        /// </remarks>
        /// <param name="model"> Model to add/update Banner </param>
        /// <returns> The Added/Updated Banner </returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("editBanner")]
        public async Task<ActionResult> EditBanner([FromForm] BannerEditModel model)
        {
            _logger.LogInformation(LogManagements.LogEditBanner);
            var bannerEdit = await _service.EditBannerAsync(model);
            if (!bannerEdit)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest, ResponseManagements.FailToEditBanner));
            }
            var result = _mapper.Map<ItemDTO>(model);
            return Ok(ApiResponse.Success(result, ResponseManagements.SuccessEditBanner));
        }

        /// <summary>
        /// Add/Update Footer Item
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Item/editFooterItem
        ///     {
        ///         "Id"= "12", (Id = 0 to Create, Id !=0 to Update)
        ///         "Title"= "Branch office",
        ///         "UrlSlug"= "branch-office"
        ///         "Address"= "9/1/2 Tran Dai Nghia Street, Ward 8, Da Lat City, Vietnam.",
        ///         "TelNumber"="Tel: +84-26-3382-8379"
        ///         "Description" = null
        ///         "InfoGmail1" = null
        ///         "InfoGmail2" = null
        ///         "Skype" = null
        ///         "Facebook" = null
        ///         "Twitter" = null
        ///         "Linkedin" = null
        ///         "Youtube" = null
        ///     }
        /// </remarks>
        /// <param name="model"> Model to add/update Footer Item </param>
        /// <returns> The Added/Updated Footer Item </returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("editFooterItem")]
        public async Task<ActionResult> EditFooterItem([FromForm] FooterEditModel model)
        {
            _logger.LogInformation(LogManagements.LogEditFooterItem);
            var footerEdit = await _service.EditFooterItemAsync(model);
            if (!footerEdit)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest, ResponseManagements.FailToEditFooterItem));
            }
            var result = _mapper.Map<ItemDTO>(model);
            return Ok(ApiResponse.Success(result, ResponseManagements.SuccessEditFooterItem));
        }

        /// <summary>
        /// Add/Update Item
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Item/edit
        ///     {
        ///         "Id"= "71", (Id = 0 to Create, Id !=0 to Update)
        ///         "JapaneseTitle"= "VALERY KHVATOV",
        ///         "Title"= "VALERY KHVATOV",
        ///         "SubTitle"="VP of Technology",
        ///         "JapaneseSubTitle"="VP of Technology",
        ///         "Description" = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod.",
        ///         "JapaneseDescription" = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod.",
        ///     }
        /// </remarks>
        /// <param name="model"> Model to add/update Item </param>
        /// <returns> The Added/Updated Item </returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("edit")]
        public async Task<ActionResult> EditItem([FromForm] ItemEditModel model)
        {
            // _logger.LogInformation(LogManagements.LogEditBanner);
            var updateSuccess = await _service.EditItemAsync(model);
            if (!updateSuccess)
            {
                return BadRequest(ApiResponse.Fail(HttpStatusCode.BadRequest, ResponseManagements.FailToEditItem));
            }
            var result = _mapper.Map<ItemDTO>(model);
            return Ok(ApiResponse.Success(result, ResponseManagements.SuccessEditItem));
        }
    }
}
