using TitanWeb.Domain.Contracts;
using TitanWeb.Domain.DTO.Items;
using TitanWeb.Domain.Entities;

namespace TitanWeb.Domain.Interfaces.Repositories
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        Task<Item> GetItemBySlugAsync(string slug);
        Task<IList<Item>> GetAllItemBySlugAsync(string slug);
        Task<IList<Item>> GetAllItemsBySectionSlugAsync(string sectionSlug, string urlSlug);
        Task<IList<Item>> GetItemByCategorySlugAsync(string categorySlug);
        Task<IPagedList<Item>> GetPagedItemAsync(ItemQuery query,
            IPagingParams pagingParams);
        Task<bool> EditItemAsync(Item item);
        Task<bool> DeleteItemAsync(int id);
        Task<bool> ChangeLogoImage(int imageId);
        Task<bool> ItemSlugExistsAsync(int id, string slug);
    }
}
