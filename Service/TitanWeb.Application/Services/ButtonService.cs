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
        /// <param name="slug"> Slug of Button want to find to change status </param>
        /// <returns> Change Status Button </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> ChangeButtonStatus(string slug)
        {
            var buttons = await _repository.GetAllButtonsAsync(slug);
            foreach(var button in buttons)
            {
                button.Status = !button.Status;
                await _repository.ChangeButtonStatus(button);
            }
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }
    }
}
