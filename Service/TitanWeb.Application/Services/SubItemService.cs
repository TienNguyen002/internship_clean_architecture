using MapsterMapper;
using TitanWeb.Api.Media;
using TitanWeb.Domain.DTO.SubItem;
using TitanWeb.Domain.Entities;
using TitanWeb.Domain.Interfaces;
using TitanWeb.Domain.Interfaces.Repositories;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Application.Services
{
    public class SubItemService : ISubItemService
    {
        private readonly ISubItemRepository _repository;
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediaManager _mediaManager;
        public SubItemService(ISubItemRepository repository, IItemRepository itemRepository, IMapper mapper, IUnitOfWork unitOfWork, IMediaManager mediaManager)
        {
            _repository = repository;
            _itemRepository = itemRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mediaManager = mediaManager;
        }

        /// <summary>
        /// Add/Update By Find Sub-Item Id, If Id > 0 Update it by Model, else Create New News By Model
        /// </summary>
        /// <param name="model"> Model to add/update </param>
        /// <returns> Added/Updated Sub-Item </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> EditSubItemAsync(SubItemEditModel model)
        {
            var subItem = model.Id > 0 ? await _repository.GetByIdWithInclude(model.Id, i => i.Items) : null;
            if (subItem == null)
            {
                subItem = new SubItem {  };
            }

            subItem.TextItem = model.TextItem;
            if (model.ImageFile != null)
            {
                subItem.Image = new Image
                {
                    ImageUrl = await _mediaManager.SaveImgFileAsync(model.ImageFile.OpenReadStream(),
                                                                     model.ImageFile.FileName,
                                                                     model.ImageFile.ContentType),
                };
            }
            var items = await _itemRepository.GetAllItemBySlugAsync(model.ItemSlug);
            if (subItem.Items.Count() == 0)
            {
                foreach (var item in items)
                {
                    subItem.Items.Add(item);
                }
            }
            await _repository.EditSubItemAsync(subItem);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Delete Sub-Item By Id
        /// </summary>
        /// <param name="id"> Id Of Sub-Item want to delete </param>
        /// <returns> Deleted Sub-Item </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteSubItemAsync(int id)
        {
            await _repository.DeleteSubItemAsync(id);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }
    }
}
