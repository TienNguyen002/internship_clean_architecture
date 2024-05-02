using TitanWeb.Domain.Interfaces;
using TitanWeb.Domain.Interfaces.Repositories;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Application.Services
{
    public class SubItemService : ISubItemService
    {
        private readonly ISubItemRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public SubItemService(ISubItemRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
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
