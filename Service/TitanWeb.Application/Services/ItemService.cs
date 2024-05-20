using MapsterMapper;
using SlugGenerator;
using TitanWeb.Domain.Collections;
using TitanWeb.Domain.Constants;
using TitanWeb.Domain.DTO;
using TitanWeb.Domain.DTO.Items;
using TitanWeb.Domain.Entities;
using TitanWeb.Domain.Interfaces;
using TitanWeb.Domain.Interfaces.Repositories;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _repository;
        private readonly ISectionRepository _sectionRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubItemRepository _subItemRepository;
        private readonly IButtonRepository _buttonRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloundinaryService _cloundinaryService;
        private readonly IMapperService _mapperService;
        public ItemService(IItemRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ISectionRepository sectionRepository,
            ICategoryRepository categoryRepository,
            ISubItemRepository subItemRepository,
            IButtonRepository buttonRepository,
            IImageRepository imageRepository,
            ICloundinaryService cloundinaryService,
            IMapperService mapperService)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _sectionRepository = sectionRepository;
            _categoryRepository = categoryRepository;
            _subItemRepository = subItemRepository;
            _buttonRepository = buttonRepository;
            _imageRepository = imageRepository;
            _cloundinaryService = cloundinaryService;
            _mapperService = mapperService;
        }

        /// <summary>
        /// Getting List Of Item With Pagination
        /// </summary>
        /// <param name="query"> Query By User Input To Get Item </param>
        /// <param name="localeQuery"> Locale of Item (en, ja) </param>
        /// <param name="pagingModel"> Model Pagination Filter </param>
        /// <returns> List Of Item Filter By Query With Pagination </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<PaginationResult<ItemDTO>> GetPagedItemAsync(ItemQuery query, LocaleQuery localeQuery,
            PagingModel pagingModel)
        {
            var result = await _repository.GetPagedItemAsync(query, pagingModel);
            var items = await _mapperService.MapPagedItemsAsync(result, localeQuery);
            var paginationResult = new PaginationResult<ItemDTO>(new PagedList<ItemDTO>(items, result.PageNumber, result.PageSize, result.TotalItemCount));
            return paginationResult;
        }

        /// <summary>
        /// Get Item By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get Item </param>
        /// <param name="localeQuery"> Locale of Item (en, ja) </param>
        /// <returns> Item With UrlSlug want to get </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ItemDTO> GetItemBySlugAsync(string slug, LocaleQuery localeQuery)
        {
            var item = await _repository.GetItemBySlugAsync(slug);
            var itemDTO = await _mapperService.MapItemAsync(item, localeQuery);
            return itemDTO;
        }

        /// <summary>
        /// Get Item By Category Slug
        /// </summary>
        /// <param name="categorySlug"> Slug of Category want to get Items </param>
        /// <param name="localeQuery"> Locale of Item (en, ja) </param>
        /// <returns> A List Of Item By Category Slug filter language </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<ItemForCategoryDTO>> GetItemsByCategorySlugAsync(string categorySlug, LocaleQuery localeQuery)
        {
            var item = await _repository.GetItemByCategorySlugAsync(categorySlug);
            var itemDTO = await _mapperService.MapItemsAsync(item, localeQuery);
            return itemDTO;
        }

        /// <summary>
        /// Get All Items By Section Slug
        /// </summary>
        /// <param name="sectionSlug"> Slug of Section want to get Items </param>
        /// <param name="urlSlug"> Url Slug of Item not take </param>
        /// <returns> A List Of Item By Section Slug except item with url slug</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<ItemForSectionDTO>> GetAllItemsBySectionSlugAsync(string sectionSlug, string urlSlug)
        {
            var item = await _repository.GetAllItemsBySectionSlugAsync(sectionSlug, urlSlug);
            return _mapper.Map<IList<ItemForSectionDTO>>(item);
        }

        /// <summary>
        /// Add/Update By Find News Id, If Id > 0 Update it by Model, else Create New News By Model
        /// </summary>
        /// <param name="model"> Model to add/update </param>
        /// <returns> Added/Updated News </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> EditNewsAsync(NewsEditModel model)
        {
            var news = model.Id > 0 ? await _repository.GetById(model.Id) : null;
            if (news == null)
            {
                news = new Item { CreatedDate = DateTime.Now, };
            }
            else news.UpdatedDate = DateTime.Now;

            news.Title = model.Title;
            news.JapaneseTitle = model.JapaneseTitle;
            news.UrlSlug = model.Title.GenerateSlug();
            if (await _repository.ItemSlugExistsAsync(model.Id, model.Title.GenerateSlug()))
            {
                int save = await _unitOfWork.Commit();
                return save < 0;
            }
            news.ShortDescription = model.ShortDescription;
            news.JapaneseShortDescription = model.JapaneseShortDescription;
            news.Description = model.Description;
            news.JapaneseDescription = model.JapaneseDescription;
            if (model.ImageFile != null)
            {
                news.Image = new Image
                {
                    ImageUrl = await _cloundinaryService.UploadImageAsync(model.ImageFile.OpenReadStream(), model.ImageFile.FileName, QueryManagements.ImageFolder),
                };
            }
            var section = await _sectionRepository.GetSectionBySlugAsync(QueryManagements.NewsSlug);
            if (section != null)
            {
                news.Section = section;
            }
            await _repository.EditItemAsync(news);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Get Item By Id
        /// </summary>
        /// <param name="id"> Id Of Item want to get </param>
        /// <returns> Get Item By Id </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ItemDetailDTO> GetItemByIdAsync(int id)
        {
            var item = await _repository.GetByIdWithInclude(id, i => i.Image, i => i.Button, i => i.SubItems);
            return _mapper.Map<ItemDetailDTO>(item);
        }

        /// <summary>
        /// Delete Item By Id
        /// </summary>
        /// <param name="id"> Id Of Item want to delete </param>
        /// <returns> Deleted Item </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteNewsAsync(int id)
        {
            await _repository.DeleteItemAsync(id);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Change Image For Item
        /// </summary>
        /// <param name="imageId"> Id Of Image want to change for Item </param>
        /// <returns> Image Item Changed </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> ChangeLogoImage(int imageId)
        {
            await _repository.ChangeLogoImage(imageId);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Add/Update By Find Blog Id, If Id > 0 Update it by Model, else Create New News By Model
        /// </summary>
        /// <param name="model"> Model to add/update </param>
        /// <returns> Added/Updated Blog </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> EditBlogsAsync(BlogEditModel model)
        {
            var blog = model.Id > 0 ? await _repository.GetById(model.Id) : null;
            if (blog == null)
            {
                blog = new Item { CreatedDate = DateTime.Now, };
            }
            else blog.UpdatedDate = DateTime.Now;

            blog.Title = model.Title;
            blog.JapaneseTitle = model.JapaneseTitle;
            blog.SubTitle = model.SubTitle;
            blog.JapaneseSubTitle = model.SubTitle;
            blog.UrlSlug = model.Title.GenerateSlug();
            if (await _repository.ItemSlugExistsAsync(model.Id, model.Title.GenerateSlug()))
            {
                int save = await _unitOfWork.Commit();
                return save < 0;
            }
            blog.ShortDescription = model.ShortDescription;
            blog.JapaneseShortDescription = model.JapaneseShortDescription;
            blog.Description = model.Description;
            blog.JapaneseDescription = model.JapaneseDescription;
            if (model.ImageFile != null)
            {
                blog.Image = new Image
                {
                    ImageUrl = await _cloundinaryService.UploadImageAsync(model.ImageFile.OpenReadStream(), model.ImageFile.FileName, QueryManagements.ImageFolder),
                };
            }
            var section = await _sectionRepository.GetSectionBySlugAsync(QueryManagements.BlogSlug);
            if (section != null)
            {
                blog.Section = section;
            }
            await _repository.EditItemAsync(blog);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Add/Update By Find Banner Id, If Id > 0 Update it by Model, else Create New News By Model
        /// </summary>
        /// <param name="model"> Model to add/update </param>
        /// <returns> Added/Updated Banner </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> EditBannerAsync(BannerEditModel model)
        {
            var banner = model.Id > 0 ? await _repository.GetById(model.Id) : null;
            if (banner == null)
            {
                banner = new Item { CreatedDate = DateTime.Now, };
            }
            else banner.UpdatedDate = DateTime.Now;

            banner.BoldTitle = model.BoldTitle;
            banner.JapaneseBoldTitle = model.JapaneseBoldTitle;
            banner.Title = model.Title;
            banner.JapaneseTitle = model.JapaneseTitle;
            banner.UrlSlug = model.Title.GenerateSlug();
            banner.Description = model.Description;
            banner.JapaneseDescription = model.JapaneseDescription;
            if (await _repository.ItemSlugExistsAsync(model.Id, model.Title.GenerateSlug()))
            {
                int save = await _unitOfWork.Commit();
                return save < 0;
            }
            banner.Description = model.Description;
            banner.IsDisplayed = model.IsDisplayed;
            if (!await ValidateBannerLimitAsync(banner))
            {
                return false;
            }
            if (model.BackgroundImage != null)
            {
                banner.Image = new Image
                {
                    ImageUrl = await _cloundinaryService.UploadImageAsync(model.BackgroundImage.OpenReadStream(), model.BackgroundImage.FileName, QueryManagements.BannerFolder),
                };
            }
            var category = await _categoryRepository.GetCategoryBySlugAsync(QueryManagements.BannerSlug);
            if (category != null)
            {
                banner.Category = category;
            }
            await _repository.EditItemAsync(banner);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Add/Update By Find Footer Item Id, If Id > 0 Update it by Model, else Create New News By Model
        /// </summary>
        /// <param name="model"> Model to add/update </param>
        /// <returns> Added/Updated Footer Item </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> EditFooterItemAsync(FooterEditModel model)
        {
            var footerItem = model.Id > 0 ? await _repository.GetById(model.Id) : null;
            if (footerItem == null)
            {
                footerItem = new Item { CreatedDate = DateTime.Now, };
            }
            else footerItem.UpdatedDate = DateTime.Now;

            footerItem.Title = model.Title;
            footerItem.JapaneseTitle = model.JapaneseTitle;
            footerItem.UrlSlug = model.Title.GenerateSlug();
            footerItem.Address = model.Address;
            footerItem.TelNumber = model.TelNumber;
            footerItem.Description = model.Description;
            footerItem.JapaneseDescription = model.JapaneseDescription;
            footerItem.InfoGmail = model.InfoGmail;
            footerItem.InfoGmail2 = model.InfoGmail2;

            var subItem = await _subItemRepository.GetByItemIdAsync(model.Id);
            if (subItem != null)
            {
                subItem.Facebook = model.Facebook;
                subItem.Twitter = model.Twitter;
                subItem.Linkedin = model.Linkedin;
                subItem.Youtube = model.Youtube;
            }

            var category = await _categoryRepository.GetCategoryBySlugAsync(QueryManagements.FooterSlug);
            if (category != null)
            {
                footerItem.Category = category;
            }
            await _subItemRepository.EditSubItemAsync(subItem);
            await _repository.EditItemAsync(footerItem);

            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Add/Update Item
        /// </summary>
        /// <param name="model"> Model to add/update Item </param>
        /// <returns> True if the item was updated successfully, False otherwise.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> EditItemAsync(ItemEditModel model)
        {
            var updatedItem = model.Id > 0 ? await _repository
                .GetByIdWithInclude(model.Id, i => i.Section) : null;
            if (updatedItem == null)
            {
                updatedItem = new Item { CreatedDate = DateTime.Now, };
            }
            else updatedItem.UpdatedDate = DateTime.Now;

            updatedItem.Title = model.Title;
            updatedItem.JapaneseTitle = model.JapaneseTitle;
            updatedItem.UrlSlug = model.Title.GenerateSlug();
            if (await _repository.ItemSlugExistsAsync(model.Id, updatedItem.UrlSlug))
            {
                int save = await _unitOfWork.Commit();
                return save < 0;
            }
            updatedItem.SubTitle = model.SubTitle;
            updatedItem.JapaneseSubTitle = model.JapaneseSubTitle;
            updatedItem.Description = model.Description;
            updatedItem.JapaneseDescription = model.JapaneseDescription;
            var button = await _buttonRepository.GetByItemIdAsync(model.Id);
            if (button != null)
            {
                button.Label = model.ButtonLabel;
                button.JapaneseLabel = model.JapaneseButtonLabel;
            }
            else
            {
                updatedItem.Button = new Button
                {
                    Label = model.ButtonLabel,
                    JapaneseLabel = model.JapaneseButtonLabel,
                };
            }
            updatedItem.IsDisplayed = true;
            if (model.ImageFile != null)
            {
                updatedItem.Image = new Image
                {
                    ImageUrl = await _cloundinaryService.UploadImageAsync(model.ImageFile.OpenReadStream(), model.ImageFile.FileName, QueryManagements.ImageFolder),
                };
            }
            var image = await _imageRepository.GetByItemIdAsync(model.Id);
            if (image != null)
            {
                image.Hyperlink = model.Hyperlink;
            }
            if (model.SectionSlug != null)
            {
                var section = await _sectionRepository.GetSectionBySlugAsync(model.SectionSlug);
                if (section != null)
                {
                    updatedItem.Section = section;
                }
            }
            if (model.CategorySlug != null)
            {
                var category = await _categoryRepository.GetCategoryBySlugAsync(model.CategorySlug);
                if (category != null)
                {
                    updatedItem.IsDisplayed = false;
                    updatedItem.Category = category;
                }
            }

            await _repository.EditItemAsync(updatedItem);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Toggles the display of a banner items
        /// </summary>
        /// <param name="itemId"> Id of the Item </param>
        /// <returns>True if the display is toggled successfully, False otherwise.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> ToggleDisplayAsync(int itemId)
        {
            var banner = await _repository.GetById(itemId);
            banner.IsDisplayed = !banner.IsDisplayed;
            if (!await ValidateBannerLimitAsync(banner))
            {
                return false;
            }
            banner.UpdatedDate = DateTime.Now;
            await _repository.EditItemAsync(banner);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Validate the banner limits
        /// </summary>
        /// <param name="item">Banner item to validate</param>
        /// <returns>True if Display is toggle and the number of banners on displayed less than 11, false otherwise.</returns>
        private async Task<bool> ValidateBannerLimitAsync(Item? item)
        {
            if (item.IsDisplayed)
            {
                var bannerList = await _repository.GetItemByCategorySlugAsync(QueryManagements.BannerSlug);
                var selectedItemsCount = bannerList.Count(i => i.IsDisplayed);
                if (selectedItemsCount > ValidateManagements.MaxBannerCount)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
