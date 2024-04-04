using TitanWeb.Domain.Entities;

namespace TitanWeb.Domain.Interfaces.Repositories
{
    public interface ISubItemRepository : IGenericRepository<SubItem>
    {
        Task<bool> EditSubItemAsync(SubItem subItem);
        Task<bool> DeleteSubItemAsync(int id);
    }
}
