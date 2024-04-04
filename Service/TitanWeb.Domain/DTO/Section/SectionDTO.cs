using TitanWeb.Domain.DTO.Items;

namespace TitanWeb.Application.DTO.Section
{
    public class SectionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string UrlSlug { get; set; }
        public string? Description { get; set; }
        public IList<ItemForSectionDTO> Items { get; set; }
        public string BackgroundUrl { get; set; }
        public string Locale { get; set; }
        public int SectionOrder { get; set; }
    }
}
