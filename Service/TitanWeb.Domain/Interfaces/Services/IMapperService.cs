using TitanWeb.Application.DTO.Section;
using TitanWeb.Domain.Contracts;
using TitanWeb.Domain.DTO;
using TitanWeb.Domain.DTO.Items;
using TitanWeb.Domain.Entities;

namespace TitanWeb.Domain.Interfaces.Services
{
    public interface IMapperService
    {
        Task<IList<ItemForCategoryDTO>> MapItemsAsync(ICollection<Item> items, LocaleQuery localeQuery);
        Task<IList<ItemDTO>> MapPagedItemsAsync(IPagedList<Item> items, LocaleQuery localeQuery);
        Task<ItemDTO> MapItemAsync(Item item, LocaleQuery localeQuery);
        Task<IList<SectionDTO>> MapSectionsAsync(ICollection<Section> sections, LocaleQuery localeQuery);
        Task<SectionDTO> MapSectionAsync(Section section, LocaleQuery localeQuery);
    }
}
