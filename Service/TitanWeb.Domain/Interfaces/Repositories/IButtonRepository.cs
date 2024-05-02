using TitanWeb.Domain.Entities;

namespace TitanWeb.Domain.Interfaces.Repositories
{
    public interface IButtonRepository : IGenericRepository<Button>
    {
        Task<IList<Button>> GetAllButtonsByItemSlugAsync(string itemSlug);
        Task<bool> ChangeButtonStatus(IList<Button> button);
    }
}
