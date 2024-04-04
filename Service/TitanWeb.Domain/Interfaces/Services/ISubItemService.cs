using TitanWeb.Domain.DTO.SubItem;

namespace TitanWeb.Domain.Interfaces.Services
{
    public interface ISubItemService
    {
        Task<bool> EditSubItemAsync(SubItemEditModel model);
        Task<bool> DeleteSubItemAsync(int id);
    }
}
