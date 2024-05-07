using MapsterMapper;
using TitanWeb.Application.DTO.Section;
using TitanWeb.Domain.Constants;
using TitanWeb.Domain.Contracts;
using TitanWeb.Domain.DTO;
using TitanWeb.Domain.DTO.Items;
using TitanWeb.Domain.Entities;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Application.Services
{
    public class MapperService : IMapperService
    {
        private readonly IMapper _mapper;
        public MapperService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IList<ItemForCategoryDTO>> MapItemsAsync(ICollection<Item> items, LocaleQuery localeQuery)
        {
            var itemDTOs = new List<ItemForCategoryDTO>();
            foreach (var item in items)
            {
                var itemDTO = _mapper.Map<ItemForCategoryDTO>(item);
                if (localeQuery.Locale == QueryManagements.Japan)
                {
                    itemDTO.BoldTitle = item.JapaneseBoldTitle;
                    itemDTO.Title = item.JapaneseTitle;
                    itemDTO.Description = item.JapaneseDescription;
                    itemDTO.ButtonLabel = item.Button?.JapaneseLabel;
                }
                itemDTOs.Add(itemDTO);
            }
            return itemDTOs;
        }

        public async Task<IList<ItemDTO>> MapPagedItemsAsync(IPagedList<Item> items, LocaleQuery localeQuery)
        {
            var itemDTOs = new List<ItemDTO>();
            foreach (var item in items)
            {
                var itemDTO = _mapper.Map<ItemDTO>(item);
                if (localeQuery.Locale == QueryManagements.Japan)
                {
                    itemDTO.BoldTitle = item.JapaneseBoldTitle;
                    itemDTO.Title = item.JapaneseTitle;
                    itemDTO.SubTitle = item.JapaneseSubTitle;
                    itemDTO.ShortDescription = item.JapaneseShortDescription;
                    itemDTO.Description = item.JapaneseDescription;
                }
                itemDTOs.Add(itemDTO);
            }
            return itemDTOs;
        }

        public async Task<ItemDTO> MapItemAsync(Item item, LocaleQuery localeQuery)
        {
            var itemDTO = _mapper.Map<ItemDTO>(item);
            if (localeQuery.Locale == QueryManagements.Japan)
            {
                itemDTO.BoldTitle = item.JapaneseBoldTitle;
                itemDTO.Title = item.JapaneseTitle;
                itemDTO.SubTitle = item.JapaneseSubTitle;
                itemDTO.ShortDescription = item.JapaneseShortDescription;
                itemDTO.Description = item.JapaneseDescription;
            }
            return itemDTO;
        }

        public async Task<IList<SectionDTO>> MapSectionsAsync(ICollection<Section> sections, LocaleQuery localeQuery)
        {
            var sectionDTOs = new List<SectionDTO>();
            foreach (var section in sections)
            {
                var sectionDTO = _mapper.Map<SectionDTO>(section);
                if (localeQuery.Locale == QueryManagements.Japan)
                {
                    sectionDTO.Title = section.JapaneseTitle;
                    sectionDTO.Description = section.JapaneseDescription;
                }
                sectionDTO.Items = new List<ItemForSectionDTO>();
                foreach (var item in section.Items)
                {
                    var itemDTO = _mapper.Map<ItemForSectionDTO>(item);
                    if (localeQuery.Locale == QueryManagements.Japan)
                    {
                        itemDTO.Title = item.JapaneseTitle;
                        itemDTO.SubTitle = item.JapaneseSubTitle;
                        itemDTO.ShortDescription = item.JapaneseShortDescription;
                        itemDTO.Description = item.JapaneseDescription;
                        itemDTO.ButtonLabel = item.Button?.JapaneseLabel;
                    }
                    sectionDTO.Items.Add(itemDTO);
                }
                sectionDTOs.Add(sectionDTO);
            }
            return sectionDTOs;
        }

        public async Task<SectionDTO> MapSectionAsync(Section section, LocaleQuery localeQuery)
        {
            var sectionDTO = _mapper.Map<SectionDTO>(section);
            if (localeQuery.Locale == QueryManagements.Japan)
            {
                sectionDTO.Title = section.JapaneseTitle;
                sectionDTO.Description = section.JapaneseDescription;
            }
            sectionDTO.Items = new List<ItemForSectionDTO>();
            foreach (var item in section.Items)
            {
                var itemDTO = _mapper.Map<ItemForSectionDTO>(item);
                if (localeQuery.Locale == QueryManagements.Japan)
                {
                    itemDTO.Title = item.JapaneseTitle;
                    itemDTO.SubTitle = item.JapaneseSubTitle;
                    itemDTO.ShortDescription = item.JapaneseShortDescription;
                    itemDTO.Description = item.JapaneseDescription;
                }
                sectionDTO.Items.Add(itemDTO);
            }
            return sectionDTO;
        }
    }
}
