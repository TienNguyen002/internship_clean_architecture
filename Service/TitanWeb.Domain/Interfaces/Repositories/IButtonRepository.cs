using TitanWeb.Domain.Entities;

namespace TitanWeb.Domain.Interfaces.Repositories
{
    public interface IButtonRepository : IGenericRepository<Button>
    {
        Task<Button> GetButtonByItemSlugAsync(string itemSlug);
        Task<bool> ChangeButtonStatus(Button button);
        Task<Button> GetByItemIdAsync(int itemId);
    }
}
