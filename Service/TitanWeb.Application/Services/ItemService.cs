using MapsterMapper;
using SlugGenerator;
using TitanWeb.Api.Media;
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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediaManager _mediaManager;
        public ItemService(IItemRepository repository, IMapper mapper, IUnitOfWork unitOfWork, IMediaManager mediaManager, ISectionRepository sectionRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mediaManager = mediaManager;
            _sectionRepository = sectionRepository;
        }

        /// <summary>
        /// Getting List Of Item With Pagination
        /// </summary>
        /// <param name="query"> Query By User Input To Get Item </param>
        /// <param name="pagingModel"> Model Pagination Filter </param>
        /// <returns> List Of Item Filter By Query With Pagination </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<PaginationResult<ItemDTO>> GetPagedItemAsync(ItemQuery query,
            PagingModel pagingModel)
        {
            var result = await _repository.GetPagedItemAsync(query, pagingModel);
            var items = _mapper.Map<List<Item>, List<ItemDTO>>(result.ToList());
            var paginationResult = new PaginationResult<ItemDTO>(new PagedList<ItemDTO>(items, result.PageNumber, result.PageSize, result.TotalItemCount));
            return paginationResult;
        }

        /// <summary>
        /// Get Item By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get Item </param>
        /// <returns> Item With UrlSlug want to get </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ItemDTO> GetItemBySlugAsync(string slug)
        {
            var item = await _repository.GetItemBySlugAsync(slug);
            return _mapper.Map<ItemDTO>(item);
        }

        /// <summary>
        /// Get Item By Category Slug
        /// </summary>
        /// <param name="categorySlug"> Slug of Category want to get Items </param>
        /// <param name="language"> Language of category want to get (en, ja) </param>
        /// <returns> A List Of Item By Category Slug filter language </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<ItemForCategoryDTO>> GetItemsByCategorySlugAsync(string categorySlug, string language)
        {
            var item = await _repository.GetItemByCategorySlugAsync(categorySlug, language);
            return _mapper.Map<IList<ItemForCategoryDTO>>(item);
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
            string uploadPath = await _mediaManager.SaveImgFileAsync(model.ImageFile.OpenReadStream(),
                                                                     model.ImageFile.FileName,
                                                                     model.ImageFile.ContentType);
            if (news == null)
            {
                news = new Item { CreatedDate = DateTime.Now, };
            }
            else news.UpdatedDate = DateTime.Now;

            news.Title = model.Title;
            news.UrlSlug = model.Title.GenerateSlug();
            news.Description = model.Description;
            news.Image = new Image
            {
                ImageUrl = uploadPath,
            };
            var sections = await _sectionRepository.GetAllSectionBySlugAsync(QueryManagements.NewsSlug);
            foreach(var section in sections)
            {
                news.Sections.Add(section);
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
        public async Task<ItemDTO> GetItemByIdAsync(int id)
        {
            var item = await _repository.GetByIdWithInclude(id, i => i.Image);
            return _mapper.Map<ItemDTO>(item);
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
            string uploadPath = await _mediaManager.SaveImgFileAsync(model.ImageFile.OpenReadStream(),
                                                                     model.ImageFile.FileName,
                                                                     model.ImageFile.ContentType);
            if (blog == null)
            {
                blog = new Item { CreatedDate = DateTime.Now, };
            }
            else blog.UpdatedDate = DateTime.Now;

            blog.Title = model.Title;
            blog.SubTitle = model.SubTitle;
            blog.UrlSlug = model.Title.GenerateSlug();
            blog.Description = model.Description;
            blog.Image = new Image
            {
                ImageUrl = uploadPath,
            };
            var sections = await _sectionRepository.GetAllSectionBySlugAsync(QueryManagements.BlogSlug);
            foreach (var section in sections)
            {
                blog.Sections.Add(section);
            }
            await _repository.EditItemAsync(blog);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }
    }
}
