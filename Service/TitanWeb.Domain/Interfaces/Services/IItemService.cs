using TitanWeb.Domain.Collections;
using TitanWeb.Domain.DTO;
using TitanWeb.Domain.DTO.Items;

namespace TitanWeb.Domain.Interfaces.Services
{
    public interface IItemService
    {
        Task<PaginationResult<ItemDTO>> GetPagedItemAsync(ItemQuery query, LocaleQuery locale, PagingModel pagingModel);
        Task<ItemDetailDTO> GetItemByIdAsync(int id);
        Task<ItemDTO> GetItemBySlugAsync(string slug, LocaleQuery query);
        Task<IList<ItemForSectionDTO>> GetAllItemsBySectionSlugAsync(string sectionSlug, string urlSlug);
        Task<IList<ItemForCategoryDTO>> GetItemsByCategorySlugAsync(string categorySlug, LocaleQuery query);
        Task<bool> EditNewsAsync(NewsEditModel model);
        Task<bool> EditBlogsAsync(BlogEditModel model);
        Task<bool> DeleteNewsAsync(int id);
        Task<bool> ChangeLogoImage(int imageId);
        Task<bool> EditBannerAsync(BannerEditModel model);
        Task<bool> EditFooterItemAsync(FooterEditModel model);
        Task<bool> EditItemAsync(ItemEditModel model);

    }
}
