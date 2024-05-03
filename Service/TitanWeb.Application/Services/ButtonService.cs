using TitanWeb.Domain.Interfaces;
using TitanWeb.Domain.Interfaces.Repositories;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Application.Services
{
    public class ButtonService : IButtonService
    {
        private readonly IButtonRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public ButtonService(IButtonRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Change status button
        /// </summary>
        /// <param name="itemSlug"> Slug of Item want to find to change button status </param>
        /// <returns> Change Status Button </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> ChangeButtonStatus(string itemSlug)
        {
            var button = await _repository.GetButtonByItemSlugAsync(itemSlug);
            if (button != null)
            {
                button.Status = !button.Status;
            }
            await _repository.ChangeButtonStatus(button);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }
    }
}
