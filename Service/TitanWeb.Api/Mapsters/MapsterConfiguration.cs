using Mapster;
using TitanWeb.Application.DTO.Section;
using TitanWeb.Domain.DTO.Category;
using TitanWeb.Domain.DTO.Image;
using TitanWeb.Domain.DTO.Items;
using TitanWeb.Domain.DTO.Section;
using TitanWeb.Domain.DTO.SubItem;
using TitanWeb.Domain.Entities;

namespace TitanWeb.Api.Mapsters
{
    public class MapsterConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Image, ImageDTO>()
                .Map(desc => desc.Id, src => src.Id);

            config.NewConfig<Item, ItemDTO>()
                .Map(desc => desc.Id, src => src.Id)
                .Map(desc => desc.ImageUrl, src => src.Image.ImageUrl);
            config.NewConfig<Item, ItemForSectionDTO>()
                .Map(desc => desc.Id, src => src.Id)
                .Map(desc => desc.ImageUrl, src => src.Image.ImageUrl)
                .Map(desc => desc.ButtonLabel, src => src.Button.Label)
                .Map(desc => desc.ButtonStatus, src => src.Button.Status);
            config.NewConfig<Item, ItemForCategoryDTO>()
                .Map(desc => desc.Id, src => src.Id)
                .Map(desc => desc.ImageUrl, src => src.Image.ImageUrl);

            config.NewConfig<Category, CategoryDTO>()
                .Map(desc => desc.Id, src => src.Id);

            config.NewConfig<Section, SectionDTO>()
                .Map(desc => desc.Id, src => src.Id)
                .Map(desc => desc.BackgroundUrl, src => src.Image.ImageUrl);
            config.NewConfig<Section, SectionForItemDTO>()
                .Map(desc => desc.Id, src => src.Id);

            config.NewConfig<SubItem, SubItemDTO>()
                .Map(desc => desc.Id, src => src.Id)
                .Map(desc => desc.Text, src => src.TextItem);
        }
    }
}
