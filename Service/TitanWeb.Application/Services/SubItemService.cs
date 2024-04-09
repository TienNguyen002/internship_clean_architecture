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
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloundinaryService _cloundinaryService;
        public SubItemService(ISubItemRepository repository, IItemRepository itemRepository, IUnitOfWork unitOfWork, ICloundinaryService cloundinaryService)
        {
            _repository = repository;
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
            _cloundinaryService = cloundinaryService;
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
                    ImageUrl = await _cloundinaryService.UploadImageAsync(model.ImageFile.OpenReadStream(), model.ImageFile.FileName),
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
