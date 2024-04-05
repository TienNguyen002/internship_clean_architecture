using TitanWeb.Domain.Entities;

namespace TitanWeb.Domain.Interfaces.Repositories
{
    public interface IButtonRepository : IGenericRepository<Button>
    {
        Task<IList<Button>> GetAllButtonsAsync(string slug);
        Task<bool> ChangeButtonStatus(Button button);
    }
}
