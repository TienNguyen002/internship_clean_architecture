﻿using TitanWeb.Domain.Collections;
using TitanWeb.Domain.DTO;
using TitanWeb.Domain.DTO.Items;

namespace TitanWeb.Domain.Interfaces.Services
{
    public interface IItemService
    {
        Task<PaginationResult<ItemDTO>> GetPagedItemAsync(ItemQuery query, PagingModel pagingModel);
        Task<ItemDTO> GetItemByIdAsync(int id); 
        Task<ItemDTO> GetItemBySlugAsync(string slug);
        Task<IList<ItemDTO>> GetItemsByCategorySlugAsync(string categorySlug, string language);
        Task<bool> EditNewsAsync(NewsEditModel model);
        Task<bool> EditBlogsAsync(BlogEditModel model);
        Task<bool> DeleteNewsAsync(int id);
        Task<bool> ChangeLogoImage(int imageId);
    }
}